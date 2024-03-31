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
        private readonly UserManager<User> userManager;

        public RestaurantController(DatabaseContext context, UserManager<User> userManager) : base(context)
        {
            this.userManager = userManager;
        }
        #region UniqueOperations

        [HttpGet("listAllRestaurants/")]
        public async Task<ActionResult<List<Restaurant>>> ListAllRestaurants() 
        {
            List<Restaurant> restaurants = await this.crudOperator.GetAllRows<Restaurant>();
            return Ok(restaurants);
        }

        /*[HttpGet("listRestaurantsByOwner/"), Authorize]
        public async Task<ActionResult<List<Restaurant>>> ListRestaurantsByOwner() 
        {
            
        }*/

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
        #endregion
    }
}
