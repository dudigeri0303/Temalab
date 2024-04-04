using BackendAPI.Controllers.Common;
using BackendAPI.Models.ModelsForApiCalls;
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
        public async Task<ActionResult<List<LikedRestaurantModel>>> GetLikedRestaurantByLoggedInUser()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<LikedRestaurant> likedRestaurants = this.crudOperator.DbContext.LikedRestaurants.Where(lr => lr.UserId == userId).ToList();
                List<LikedRestaurantModel> likedRestaurantModels = new List<LikedRestaurantModel>();
                foreach(var lr in likedRestaurants)
                {
                    Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(lr.RestaurantId);
                    if (restaurant != null) 
                    {
                        likedRestaurantModels.Add(new LikedRestaurantModel
                        {
                            Id = lr.Id,
                            Name = restaurant.Name,
                            Label = restaurant.Label,
                            Description = restaurant.Description,
                            Location = $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber.ToString()}" 
                        }) ; 
                    }
                }
                return Ok(likedRestaurantModels);
            }
            return NotFound("User not found");
        }

        [HttpPost("likeRestaurantForLoggedInUser"), Authorize]
        public async Task<ActionResult<LikedRestaurant>> LikeRestaurantForLoggedInUser(string restaurantId) 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await this.userManager.FindByIdAsync(userId);
            LikedRestaurant? alreadyLiked = this.crudOperator.DbContext.LikedRestaurants
                .Where(lr => lr.UserId == userId && lr.RestaurantId == restaurantId)
                .FirstOrDefault();
            if (user != null) 
            {
                if(alreadyLiked == null) 
                {
                    Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                    LikedRestaurant likedRestaurant = new LikedRestaurant(user, restaurant);
                    await this.crudOperator.InsertNewRow<LikedRestaurant>(likedRestaurant);
                    return Ok("Restaurant liked");
                }
                return BadRequest("User already liked the restaurant");
            }
            return NotFound("User not found");
        }

        [Authorize]
        [HttpDelete("deleteLikedRestaurantForLoggedUser/")]
        public async Task<ActionResult> DeleteLikedRestaurantByIdForLoggedUser(string likedRestaurantId)
        {
            try
            {
                await this.crudOperator.DeleteRowById<LikedRestaurant>(likedRestaurantId);
                return Ok("Liked restaurant deleted");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        #endregion
    }
}
