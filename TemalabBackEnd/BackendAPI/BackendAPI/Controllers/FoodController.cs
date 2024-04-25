using BackendAPI.Controllers.Common;
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

        [HttpGet("GetMenuItems")]
        public async Task<ActionResult<List<List<Food>>>> GetMenuItems(string restaurantId)
        {
            try {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                string? menu = restaurant.MenuId;
                List<Category> categories = await this.crudOperator.GetMultipleRowsByForeignId<Category>(menu, "MenuId");
                List<List<Food>> menuItems = new List<List<Food>>();
                foreach (Category category in categories)
                {
                    List<Food> foods = await this.crudOperator.GetMultipleRowsByForeignId<Food>(category.Id, "CategoryId");
                    menuItems.Add(foods);
                }

                return Ok(menuItems);
            }
            catch (Exception ex) { return BadRequest(ex.Message);}
            
        }

        #endregion
    }
}
