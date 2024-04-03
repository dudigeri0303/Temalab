using BackendAPI.Controllers.Common;
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

        [HttpGet("listAllRestaurants/")]
        public async Task<ActionResult<List<Restaurant>>> ListAllRestaurants() 
        {
            List<Restaurant> restaurants = await this.crudOperator.GetAllRows<Restaurant>();
            return Ok(restaurants);
        }
        [HttpGet("listRestaurantsByOwner/"), Authorize]
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
        [HttpPost("createNewRestaurantWithOwner/"), Authorize]
        public async Task<ActionResult> CreateRestaurantWithOwner(Restaurant restaurant) 
        {
            try 
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId);
                await this.crudOperator.InsertNewRow<Restaurant>(restaurant);
                await this.crudOperator.InsertNewRow<Owner>(new Owner(user, restaurant));
                return Ok("Restaurant added to database and owner created");
            }
            catch (Exception ex) 
            {
                return BadRequest("Something went wrong" + "\n" + ex.Message);
            }
        }

        //2 kontroller a menü kezeléséhez.KAtegória hozzáadása a menühoz étterem id alapján
        //és kaja hozzáadása a kategóriához kategória id alapján
        [HttpPost("addCategoryToMenu/"), Authorize]
        public async Task<ActionResult<Category>> AddCategoryToMenu(string restaurantID, string categoryName) 
        {
            Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantID);
            Menu? menu = await this.crudOperator.GetRowById<Menu>(restaurant.MenuId);
            if(menu != null) 
            {
                Category category = new Category(menu, categoryName);
                await this.crudOperator.InsertNewRow<Category>(category);
                return Ok(category);
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost("addFoodToCategory"), Authorize]
        public async Task<ActionResult<Food>> AddFoodToCategory(string categoryId, string name, string description, int price) 
        {
            Category? category = await this.crudOperator.GetRowById<Category>(categoryId);
            if(category != null) 
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
