using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class CategoryController : BaseEntityController
    {
        public CategoryController([FromServices] DatabaseContext dbContext, [FromServices] UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        #region UniqueOperations

        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> AddCategory(string restaurantId, CreateCategoryDto createCategoryDto)
        {
            try
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                if (restaurant != null)
                {
                    Category category = new Category
                    {
                        Name = createCategoryDto.Name,
                        MenuId = restaurant.MenuId
                    };
                    await this.crudOperator.InsertNewRow<Category>(category);
                    return Ok(category);
                }
                return NotFound("Restaurant not found:(");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [HttpGet("listCategoriesByRestaurantId/")]
        public async Task<ActionResult<List<CategoryDto>>> ListCategoriesByRestaurantId(string restaurantId) 
        {
            Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
            if (restaurant != null)
            {
                string menuId = restaurant.MenuId;
                List<Category> categoriesForMenu = await this.crudOperator.GetMultipleRowsByForeignId<Category>(menuId, "MenuId");
                List<CategoryDto> categorieDtos = new List<CategoryDto>();
                categoriesForMenu.ForEach(c => categorieDtos.Add(new CategoryDto(c.Id, c.Name)));
                return Ok(categorieDtos);
            }
            return NotFound("Could not found the restaurant by the id");
        }

        [HttpDelete("deleteCategoryById/")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult> DeleteCategoryById(string categoryId)
        {
            try
            {
                //delete foods
                List<Food> foods = await this.crudOperator.GetMultipleRowsByForeignId<Food>(categoryId, "CategoryId");
                foreach (Food food in foods)
                {
                    await this.crudOperator.DeleteRowById<Food>(food.Id);
                }
                //delete category
                await this.crudOperator.DeleteRowById<Category>(categoryId);
                return Ok("Category deleted succesfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
