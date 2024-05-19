using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Models.EntityFrameworkModel.EntityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : BaseEntityController
    {
        public RestaurantController(DatabaseContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }
        #region UniqueOperations

        [Authorize(Roles = "Customer")]
        [HttpGet("listAllRestaurants/")]
        public async Task<ActionResult<List<RestaurantDataDto>>> ListAllRestaurants() 
        {
            try 
            {
                List<Restaurant> restaurants = await this.crudOperator.GetAllRows<Restaurant>();
                List<RestaurantDataDto> restaurantDtos = new List<RestaurantDataDto>();
                foreach (var restaurant in restaurants) 
                {
                    List<RestaurantOpeningHours> openingHours = await this.crudOperator.GetMultipleRowsByForeignId<RestaurantOpeningHours>(restaurant.Id, "RestaurantId");
                    List<OpeningHourDto> openingHourDtos = new List<OpeningHourDto>();
                    openingHours.ForEach(openingHour => openingHourDtos.Add(new OpeningHourDto(openingHour.DayName, openingHour.OpeningHour)));
                    restaurantDtos.Add(new RestaurantDataDto(restaurant.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}", openingHourDtos));
                }
                return Ok(restaurantDtos);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [Authorize(Roles = "Customer")]
        [HttpGet("listRestaurantsByOwner/")]
        public async Task<ActionResult<List<Restaurant>>> ListRestaurantsByOwner() 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Owner> ownerConnections = await this.crudOperator.GetMultipleRowsByForeignId<Owner>(userId, "UserId");
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach(Owner owner in ownerConnections) 
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(owner.RestaurantId);
                restaurants.Add(restaurant);
            }
            return Ok(restaurants);
        }

        [HttpGet("GetRestaurantById")]
        public async Task<ActionResult<RestaurantDataDto>> GetRestaurantById(string restaurantId)
        {
            try
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                List<RestaurantOpeningHours> openingHours = await this.crudOperator.GetMultipleRowsByForeignId<RestaurantOpeningHours>(restaurantId, "RestaurantId");
                List<OpeningHourDto> openingHourDtos = new List<OpeningHourDto>();
                openingHours.ForEach(oh => openingHourDtos.Add(new OpeningHourDto(oh.DayName, oh.OpeningHour)));
                RestaurantDataDto restaurantDto = new RestaurantDataDto(restaurant.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}", openingHourDtos);
                return Ok(restaurantDto);
            }
            catch (Exception ex) 
            {
                return BadRequest("Couldnt find the restaurnat");
            }
        }

        //Így működik a menu lekérése, viszont navigation property alapján nem, pedig kéne.(szerintem feleselges, mert a menu csak egy id)
        [HttpGet("GetRestaurantMenu")]
        public async Task<ActionResult<Menu>> GetRestaurantMenu(string id)
        {
            Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(id);
            if (restaurant != null) 
            {
                Menu? menu = await this.crudOperator.GetRowById<Menu>(restaurant.MenuId);
                if (menu != null)
                {
                    return Ok(menu);
                }
            }
            return BadRequest("Couldnt find the menu");
        }

        [HttpPut("updateRestaurantById/")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<Restaurant>> UpdateRestaurantById(string restaurantId, UpdateRestaurantDto updateRestaurantDto) 
        {
            Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
            if(restaurant != null)
            {
                try
                {
                    restaurant.Name = updateRestaurantDto.Name!;
                    restaurant.PostCode = Int32.Parse(updateRestaurantDto.PostCode!);
                    restaurant.City = updateRestaurantDto.City!;
                    restaurant.Street = updateRestaurantDto.Street!;
                    restaurant.HouseNumber = Int32.Parse(updateRestaurantDto?.HouseNumber!);
                    restaurant.PhoneNumber = updateRestaurantDto.PhoneNumber!;
                    restaurant.Description = updateRestaurantDto.Description!;
                    restaurant.Label = updateRestaurantDto.Label!;
                    this.crudOperator.UpdateRow<Restaurant>(restaurant);
                    return Ok(restaurant);
                }
                catch (Exception ex) 
                {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound("Restaurant nod found");
        }

        [HttpDelete("deleteRestaurantById/")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult> DeleteRestaurantById(string restaurantId)
        {
            try
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                if (restaurant != null)
                {
                    //delete categories and foods
                    List<Category> categories = await this.crudOperator.GetMultipleRowsByForeignId<Category>(restaurant.MenuId, "MenuId");
                    foreach (Category category in categories)
                    {
                        //delete foods
                        List<Food> foods = await this.crudOperator.GetMultipleRowsByForeignId<Food>(category.Id, "CategoryId");
                        foreach (Food food in foods)
                        {
                            await this.crudOperator.DeleteRowById<Food>(food.Id);
                        }
                        await this.crudOperator.DeleteRowById<Category>(category.Id);
                    }

                    //delete menu
                    Menu? menu = await this.crudOperator.GetRowById<Menu>(restaurant.MenuId);
                    await this.crudOperator.DeleteRowById<Menu>(menu.Id);

                    //delete reservations
                    List<Reservation> reservations = await this.crudOperator.GetMultipleRowsByForeignId<Reservation>(restaurantId, "RestaurantId");
                    foreach (Reservation reservation in reservations)
                    {
                        this.crudOperator.DbContext.Reservations.Remove(reservation);
                    }

                    //delete restaurant
                    await this.crudOperator.DeleteRowById<Restaurant>(restaurantId);
                    return Ok("Restaurant deleted");
                }
                return NotFound("Restaurant not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
