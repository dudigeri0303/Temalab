using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Models.EntityFrameworkModel.EntityModels;
using BackendAPI.Services.Implementations;
using BackendAPI.Services.Interfaces;
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
    public class OwnerController : BaseEntityController
    {

        private IOwnerService ownerService;

        public OwnerController([FromServices] DatabaseContext dbContext, [FromServices] UserManager<User> userManager, [FromServices] IOwnerService ownerService) 
            : base(dbContext, userManager)
        {
            this.ownerService = ownerService;
        }
        #region UniqueOperations
        [Authorize(Roles = "Owner")]
        [HttpGet("listRestaurantsByOwner/")]
        public async Task<ActionResult<List<RestaurantDataDto>>> ListRestaurantsByOwner()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await this.ownerService.ListRestaurantsByOwner(userId!, this.crudOperator);
        }

        [Authorize(Roles = "Owner")]
        [HttpPost("createNewRestaurantWithOwner/")]
        public async Task<ActionResult<Restaurant>> CreateRestaurantWithOwner(CreateRestaurantDto restaurantDto)
        {
            try
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId!);
                //Ezt a ronda if statement-et valahogy ki kéne küszöbölni.
                if (restaurantDto.Name != null && restaurantDto.Description != null && restaurantDto.Label != null &&
                    restaurantDto.City != null && restaurantDto.Street != null && restaurantDto.HouseNumber != null &&
                    restaurantDto.PostCode != null && restaurantDto.PhoneNumber != null && user != null)
                {
                    Restaurant restaurant = new Restaurant(restaurantDto.Name, restaurantDto.Description, restaurantDto.Label,
                      restaurantDto.City, restaurantDto.Street, Int32.Parse(restaurantDto.HouseNumber), Int32.Parse(restaurantDto.PostCode), restaurantDto.PhoneNumber);
                    
                    List<OpeningHourDto> openingHourDtos = restaurantDto.openingHours; 
                    
                    await this.crudOperator.InsertNewRow<Restaurant>(restaurant);
                    await this.crudOperator.InsertNewRow<Owner>(new Owner(user, restaurant));
                    
                    foreach (var ohdto in openingHourDtos) 
                    {
                        await this.crudOperator.InsertNewRow<RestaurantOpeningHours>(new RestaurantOpeningHours(restaurant, ohdto.dayName, ohdto.openingHour));
                    }
                    
                    return Ok(restaurant);
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + "\n" + ex.Message);
            }
        }

        //2 kontroller a menü kezeléséhez.KAtegória hozzáadása a menühoz étterem id alapján
        //és kaja hozzáadása a kategóriához kategória id alapján
        [Authorize(Roles = "Owner")]
        [HttpPost("addCategoryToMenu/")]
        public async Task<ActionResult<Category>> AddCategoryToMenu(string restaurantID, string categoryName)
        {
            Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantID);
            Menu? menu = await this.crudOperator.GetRowById<Menu>(restaurant.MenuId);
            if (menu != null)
            {
                Category category = new Category(menu, categoryName);
                await this.crudOperator.InsertNewRow<Category>(category);
                return Ok(category);
            }
            return BadRequest("Something went wrong");
        }
        [Authorize(Roles = "Owner")]
        [HttpPost("addFoodToCategory")]
        public async Task<ActionResult<Food>> AddFoodToCategory(string categoryId, string name, string description, int price)
        {
            Category? category = await this.crudOperator.GetRowById<Category>(categoryId);
            if (category != null)
            {
                Food food = new Food(category, name, description, price);
                await this.crudOperator.InsertNewRow<Food>(food);
                return Ok(food);
            }
            return BadRequest("Something went wrong");
        }
        #endregion
    }
}
