﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedRestaurantController : BaseEntityController<LikedRestaurant>
    {
        public LikedRestaurantController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        #region UniqueApiCalls
        [HttpGet("getLikedRestaurantForLoggedInUser/"), Authorize]
        public async Task<ActionResult<List<Restaurant>>> GetLikedRestaurantByLoggedInUser()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<LikedRestaurant> likedRestaurants = this._dbContext.LikedRestaurants.Where(lr => lr.UserId == userId).ToList();
                List<Restaurant> actualRestaurants = new List<Restaurant>();
                foreach(var lr in likedRestaurants)
                {
                    actualRestaurants.Add(this._dbContext.Restaurants.Where(r => r.Id == lr.RestaurantId).FirstOrDefault());
                }
                return Ok(actualRestaurants);
            }
            return NotFound("User not found");
        }
        #endregion
    }
}
