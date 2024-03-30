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
    public class RestaurantController : BaseEntityController<Restaurant>
    {
        private readonly UserManager<User> userManager;

        public RestaurantController(DatabaseContext context, UserManager<User> userManager) : base(context)
        {
            this.userManager = userManager;
        }
        #region UniqueOperations

        [HttpPost("createNewRestaurantWithOwner/"), Authorize]
        public async Task<ActionResult> CreateRestaurantWithOwner(Restaurant restaurant) 
        {
            try 
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId);
                this.InsertNewRow(restaurant);
                this._dbContext.Owners.Add(new Owner(user, restaurant));
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
