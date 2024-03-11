using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OwnerController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet("getRestaurantsByOwnerID/{id}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantsByOwner(int id)
        {
            List<Owner> restaurantOwnedById = this._context.Owners.Where(o => o.Id == id).ToList();
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
        }
    }
}
