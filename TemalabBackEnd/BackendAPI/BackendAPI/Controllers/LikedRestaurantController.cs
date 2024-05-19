using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Services.Interfaces;
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
        private ILikedRestaurantService likedRestaurantService;

        public LikedRestaurantController([FromServices] DatabaseContext dbContext, [FromServices] UserManager<User> userManager, [FromServices] ILikedRestaurantService likedRestaurantService) : base(dbContext, userManager)
        {
            this.likedRestaurantService = likedRestaurantService;
        }

        #region UniqueApiCalls
        [HttpGet("getLikedRestaurantForLoggedInUser/")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<List<LikedRestaurantDto>>> GetLikedRestaurantByLoggedInUser()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await this.likedRestaurantService.GetLikedRestaurantByLoggedInUser(userId!, this.crudOperator);
            
        }
        [HttpPost("likeRestaurantForLoggedInUser")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<LikedRestaurant>> LikeRestaurantForLoggedInUser(string restaurantId) 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await this.userManager.FindByIdAsync(userId!);
            LikedRestaurant? alreadyLiked = this.crudOperator.DbContext.LikedRestaurants
                .Where(lr => lr.UserId == userId && lr.RestaurantId == restaurantId)
                .FirstOrDefault();
            if (user != null) 
            {
                if(alreadyLiked == null) 
                {
                    Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                    LikedRestaurant likedRestaurant = new LikedRestaurant(user, restaurant!);
                    await this.crudOperator.InsertNewRow<LikedRestaurant>(likedRestaurant);
                    return Ok("Restaurant liked");
                }
                return BadRequest("User already liked the restaurant");
            }
            return NotFound("User not found");
        }

        [HttpDelete("deleteLikedRestaurantForLoggedUser/")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> DeleteLikedRestaurantByIdForLoggedUser(string likedRestaurantId)
        {
            return await this.likedRestaurantService.DeleteLikedRestaurantByIdForLoggedUser(likedRestaurantId, this.crudOperator);
        }
        #endregion
    }
}
