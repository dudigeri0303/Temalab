using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : BaseEntityController
    {
        public FoodController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        #region UniqueOperations

        [HttpGet("GetMenuItems/")]
        public async Task<ActionResult<List<List<FoodDto>>>> GetMenuItems(string restaurantId)
        {
            try {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                string? menu = restaurant.MenuId;
                List<Category> categories = await this.crudOperator.GetMultipleRowsByForeignId<Category>(menu, "MenuId");
                List<List<FoodDto>> menuItems = new List<List<FoodDto>>();
                foreach (Category category in categories)
                {
                    List<Food> foods = await this.crudOperator.GetMultipleRowsByForeignId<Food>(category.Id, "CategoryId");
                    List<FoodDto> items = new List<FoodDto>();
                    foods.ForEach(f => items.Add(new FoodDto(f.Id, f.Name, f.Description, f.Price, f.Image)));
                    menuItems.Add(items);
                }
                return Ok(menuItems);
            }
            catch (Exception ex) { return BadRequest(ex.Message);}
        }

        [HttpGet("getMenuItemsByCategoryId/")]
        public async Task<ActionResult<FoodDto>> GetMenuItemsByCategoryId(string categoryId)
        {
            List<Food> foods = await this.crudOperator.GetMultipleRowsByForeignId<Food>(categoryId, "CategoryId");
            if(foods.Any()) 
            {
                List<FoodDto> foodDtos = new List<FoodDto>();
                foods.ForEach(f => foodDtos.Add(new FoodDto(f.Id, f.Name, f.Description, f.Price, f.Image)));
                return Ok(foodDtos);
            }
            return BadRequest("There are no foods for this category");
        }
        
        [HttpDelete("deleteFoodByID/")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult> DeleteFoodByID(string foodId) 
        {
            try
            {
                await this.crudOperator.DeleteRowById<Food>(foodId);
                return Ok("Food deleted succesfully!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addNewFoodToCategory/")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<Food>> AddNewFoodToCategory(string categoryId, CreateFoodDto foodDto) 
        {
            try 
            {
                Category? category = await this.crudOperator.GetRowById<Category>(categoryId);
                if (category != null) 
                {
                    Food food = new Food(category, foodDto.Name, foodDto.Description, foodDto.Price);
                    await this.crudOperator.InsertNewRow<Food>(food);   
                    return Ok(food);
                }
                return NotFound("Category was not found by the id");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("addImageToFood/")]
        [Authorize(Roles ="Owner")]
        public async Task<ActionResult> AddImageToFood(string foodId, [FromForm]IFormFile imageFile)
        {
            try 
            {
                byte[] imageBytes = await ImageToByteArrayConverter.FileToByteArray(imageFile);
                Food? food = await this.crudOperator.GetRowById<Food>(foodId);
                food!.Image = imageBytes;
                this.crudOperator.SaveDatabaseChanges();
                return Ok(food);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
