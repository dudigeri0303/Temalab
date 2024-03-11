using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<ActionResult<List<Owner>>> GetAllOwner()
        {
            List<Owner> owners = await _context.Owners.ToListAsync();
            return Ok(owners);
        }

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

        //HTTP Delete
        [HttpDelete("deleteByID/{id}")]
        public async Task<ActionResult<Owner>> DeleteOwnerById(int id)
        {
            //Owner ownerToDelete = this.GetOwnerById(id).Result;
            Owner owner = await this._context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound("Owner not fount, you cant delete it");
            }
            this._context.Owners.Remove(owner);
            this._context.SaveChanges();
            return Ok(owner);
        }

        //HTTP POST
        [HttpPost("createNewOwner/")]
        public async Task<ActionResult> CreateNewOwner(Owner owner)
        {
            try
            {
                this._context.Owners.Add(owner);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(owner);
        }
    }
}
