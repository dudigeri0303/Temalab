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
    public class LikedRestaurantController : BaseEntityController
    {
        public LikedRestaurantController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        #region UniqueApiCalls
        [HttpGet("getLikedRestaurantForLoggedInUser/"), Authorize]
        public async Task<ActionResult<List<Restaurant>>> GetLikedRestaurantByLoggedInUser()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<LikedRestaurant> likedRestaurants = this.crudOperator.DbContext.LikedRestaurants.Where(lr => lr.UserId == userId).ToList();
                List<Restaurant> actualRestaurants = new List<Restaurant>();
                foreach(var lr in likedRestaurants)
                {
                    actualRestaurants.Add(this.crudOperator.DbContext.Restaurants.Where(r => r.Id == lr.RestaurantId).FirstOrDefault());
                }
                return Ok(actualRestaurants);
            }
            return NotFound("User not found");
        }

        [HttpPost("likeRestaurantForLoggedInUser"), Authorize]
        public async Task<ActionResult<LikedRestaurant>> LikeRestaurantForLoggedInUser(string restaurantId) 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null) 
            {
                LikedRestaurant likedRestaurant = new LikedRestaurant();
            }
            return NotFound("User not found");
        }
        #endregion
    }
}
