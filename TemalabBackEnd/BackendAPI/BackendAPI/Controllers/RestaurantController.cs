using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                    restaurantDtos.Add(new RestaurantDataDto(restaurant.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}"));
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
        public async Task<ActionResult<RestaurantDataDto>> GetRestaurantById(string id)
        {
            try
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(id);
                RestaurantDataDto restaurantDto = new RestaurantDataDto(restaurant.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}");
                return Ok(restaurantDto);
            }
            catch (Exception ex) 
            {
                return BadRequest("Couldnt find the restaurnat");
            }
        }

        //Így működik a menu lekérése, viszont navigation property alapján nem, pedig kéne.
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
        #endregion
    }
}
