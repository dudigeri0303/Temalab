using BackendAPI.Controllers.Common;
using BackendAPI.Models.ModelsForApiCalls;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class CategoryController : BaseEntityController
    {
        public CategoryController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        #region UniqueOperations

        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> AddCategory(string restaurantId, CreateCategoryModel createCategoryModel)
        {
            try
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                Category category = new Category
                {
                    Name = createCategoryModel.Name,
                    MenuId = restaurant.MenuId
                };
                await this.crudOperator.InsertNewRow<Category>(category);

                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }          

        }

        #endregion
    }
}
