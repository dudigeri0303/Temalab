using BackendAPI.Controllers.Common;
using BackendAPI.Models.ModelsForApiCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : BaseEntityController
    {
        public OwnerController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {

        }
        #region UniqueOperations
        [Authorize(Roles = "Owner")]
        [HttpGet("listRestaurantsByOwner/")]
        public async Task<ActionResult<List<RestaurantModel>>> ListRestaurantsByOwner()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Owner> ownerConnections = await this.crudOperator.GetMultipleRowsByForeignId<Owner>(userId, "UserId");
            List<RestaurantModel> restaurantModels = new List<RestaurantModel>();
            foreach (Owner owner in ownerConnections)
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(owner.RestaurantId);
                restaurantModels.Add(new RestaurantModel 
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Label = restaurant.Label,
                    Description = restaurant.Description,
                    Location = $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}"
                });
            }
            return Ok(restaurantModels);
        }

        [Authorize(Roles = "Owner")]
        [HttpPost("createNewRestaurantWithOwner/")]
        public async Task<ActionResult<Restaurant>> CreateRestaurantWithOwner(CreateRestaurantModel restaurantModel)
        {
            try
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId);
                Restaurant restaurant = new Restaurant(
                    restaurantModel.Name,
                    restaurantModel.Description, 
                    restaurantModel.Label, 
                    restaurantModel.City, 
                    restaurantModel.Street,
                    Int32.Parse(restaurantModel.HouseNumber),
                    Int32.Parse(restaurantModel.PostCode),
                    restaurantModel.PhoneNumber, 
                    "00-24");
                await this.crudOperator.InsertNewRow<Restaurant>(restaurant);
                await this.crudOperator.InsertNewRow<Owner>(new Owner(user, restaurant));
                return Ok(restaurant);
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

        /* TODO: Get owner by restaurant
        [HttpGet("getRestaurantsByOwnerID/{id}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantsByOwner(int id)
        {
            List<Owner> restaurantOwnedById = this._context.Owners.Where(o => o.UserId == id).ToList();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var owner in restaurantOwnedById)
            {
                foreach (var restaurant in this._context.Restaurants)
                {
                    if (owner.RestaurantId == restaurant.Id)
                    {
                        restaurants.Add(restaurant);
                    }
                }
            }
            if (restaurantOwnedById.Count < 1)
            {
                return NotFound("Owner not found");
            }
            return Ok(restaurants);
        }*/

        #endregion
    }
}
