﻿using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
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
        [Authorize(Roles = "Customer")]
        [HttpGet("getLikedRestaurantForLoggedInUser/")]
        public async Task<ActionResult<List<LikedRestaurantDto>>> GetLikedRestaurantByLoggedInUser()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<LikedRestaurant> likedRestaurants = this.crudOperator.DbContext.LikedRestaurants.Where(lr => lr.UserId == userId).ToList();
                List<LikedRestaurantDto> likedRestaurantModels = new List<LikedRestaurantDto>();
                foreach(var lr in likedRestaurants)
                {
                    Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(lr.RestaurantId);
                    if (restaurant != null) 
                    {
                        likedRestaurantModels.Add(new LikedRestaurantDto(lr.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber.ToString()}", restaurant.Id)); 
                    }
                }
                return Ok(likedRestaurantModels);
            }
            return NotFound("User not found");
        }
        [Authorize(Roles = "Customer")]
        [HttpPost("likeRestaurantForLoggedInUser")]
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

        [Authorize(Roles = "Customer")]
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
