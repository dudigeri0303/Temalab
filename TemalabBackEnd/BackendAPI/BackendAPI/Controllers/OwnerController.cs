using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : BaseEntityController<Owner>
    {
        public OwnerController(DatabaseContext context) : base(context)
        {

        }

        #region CrudOperations

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, Owner updatedEntity) 
        {
            return Ok("No update operation for owner!");
        }
        #endregion

        #region niqueOperations

        [HttpGet("getRestaurantsByOwnerID/{id}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantsByOwner(int id)
        {
            List<Owner> restaurantOwnedById = this._dbContext.Owners.Where(o => o.UserId == id).ToList();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var owner in restaurantOwnedById)
            {
                foreach (var restaurant in this._dbContext.Restaurants)
                {
                    if (owner.RestaurantId == restaurant.Id)
                    {
                        restaurants.Add(restaurant);
                    }
                }
            }
            if (restaurantOwnedById.Count < 1)
            {
                return NotFound("Owner not found");
            }
            return Ok(restaurants);
        }

        /* TODO: Get owner by restaurant
        [HttpGet("getRestaurantsByOwnerID/{id}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantsByOwner(int id)
        {
            List<Owner> restaurantOwnedById = this._context.Owners.Where(o => o.UserId == id).ToList();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var owner in restaurantOwnedById)
            {
                foreach (var restaurant in this._context.Restaurants)
                {
                    if (owner.RestaurantId == restaurant.Id)
                    {
                        restaurants.Add(restaurant);
                    }
                }
            }
            if (restaurantOwnedById.Count < 1)
            {
                return NotFound("Owner not found");
            }
            return Ok(restaurants);
        }*/

        #endregion
    }
}
