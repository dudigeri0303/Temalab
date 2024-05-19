using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Services.Implementations
{
    public class LikedRestaurantService : ILikedRestaurantService
    {
        public async Task<ActionResult> DeleteLikedRestaurantByIdForLoggedUser(string likedRestaurantId, GenericCrudOperator crudOperator)
        {
            try
            {
                await crudOperator.DeleteRowById<LikedRestaurant>(likedRestaurantId);
                return new OkObjectResult("Liked restaurant deleted");
            }
            catch (Exception ex) 
            { 
                return new BadRequestObjectResult(ex.Message); 
            }
        }

        public async Task<ActionResult<List<LikedRestaurantDto>>> GetLikedRestaurantByLoggedInUser(string userId, GenericCrudOperator crudOperator)
        {
            if (userId != null)
            {
                List<LikedRestaurant> likedRestaurants = crudOperator.DbContext.LikedRestaurants.Where(lr => lr.UserId == userId).ToList();
                List<LikedRestaurantDto> likedRestaurantModels = new List<LikedRestaurantDto>();
                foreach (var lr in likedRestaurants)
                {
                    Restaurant? restaurant = await crudOperator.GetRowById<Restaurant>(lr.RestaurantId);
                    if (restaurant != null)
                    {
                        likedRestaurantModels.Add(new LikedRestaurantDto(lr.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber.ToString()}", restaurant.Id));
                    }
                }
                return new OkObjectResult(likedRestaurantModels);
            }
            return new NotFoundObjectResult("User not found");
        }
    }
}
