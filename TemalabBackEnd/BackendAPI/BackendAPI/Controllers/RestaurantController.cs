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
    public class RestaurantController : BaseEntityController
    {
        public RestaurantController(DatabaseContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }
        #region UniqueOperations

        [Authorize(Roles = "Customer")]
        [HttpGet("listAllRestaurants/")]
        public async Task<ActionResult<List<RestaurantModel>>> ListAllRestaurants() 
        {
            try 
            {
                List<Restaurant> restaurants = await this.crudOperator.GetAllRows<Restaurant>();
                List<RestaurantModel> restaurantModels = new List<RestaurantModel>();
                foreach (var restaurant in restaurants) 
                {
                    restaurantModels.Add(new RestaurantModel 
                    {
                        Id = restaurant.Id,
                        Name = restaurant.Name,
                        Label = restaurant.Label,
                        Description = restaurant.Description,
                        Location = $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}"
                    });
                }
                return Ok(restaurantModels);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [Authorize(Roles = "Customer")]
        [HttpGet("listRestaurantsByOwner/")]
        public async Task<ActionResult<List<Restaurant>>> ListRestaurantsByOwner() 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Owner> ownerConnections = await this.crudOperator.GetMultipleRowsByForeignId<Owner>(userId, "UserId");
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach(Owner owner in ownerConnections) 
            {
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(owner.RestaurantId);
                restaurants.Add(restaurant);
            }
            return Ok(restaurants);
        }
        
        #endregion
    }
}
