using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public RestaurantController(DatabaseContext context) 
        {
            this._context = context;
        }

        //HTTP GET//
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("getOwnerByRestaurantID/{id}")]
        public async Task<ActionResult<Owner>> GetOwnerByRestaurantId(int id) 
        {
            Owner? owner = await this._context.Owners.Where(o => o.RestaurantId == id).FirstOrDefaultAsync();
            if(owner == null) 
            {
                NotFound("Restaurant not found");
            }
            return Ok(owner);
        }

        [HttpGet("getRestaurantByOwnerName/{name}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantByOwnerName(string name)
        {
            List<int> ownerIds = this._context.Users.Where(u => u.UserName == name).Select(u => u.Id).ToList();
            List<Owner> owners = new List<Owner>();
            foreach(int id in ownerIds) 
            {
                foreach(var owner in this._context.Owners) 
                {
                    if (id == owner.UserId) 
                    {
                        owners.Add(owner);
                    }
                }
            }
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var owner in owners)
            {
                foreach (var restaurant in this._context.Restaurants)
                {
                    if (owner.RestaurantId == restaurant.Id)
                    {
                        restaurants.Add(restaurant);
                    }
                }
            }
            if (restaurants == null)
            {
                NotFound("");
            }
            return Ok(restaurants);
        }


        //HTTP DELETE//
        [HttpDelete("deleteByID/{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurantById(int id)
        {
            //Restaurant restaurantToDelete = this.GetRestaurantById(id).Result;
            Restaurant? restaurant = await this._context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound("Restaurant not fount, you cant delete it");
            }
            this._context.Restaurants.Remove(restaurant);
            this._context.SaveChanges();
            return Ok(restaurant);
        }

        //HTTP POST
        [HttpPost("createNewRestaurant/")]
        public async Task<ActionResult> CreateNewRestaurant(Restaurant restaurant)
        {
            try
            {
                this._context.Restaurants.Add(restaurant);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(restaurant);
        }

        //TODO password validation
        [HttpPut("updateRestaurantPropertiesByID/{id}")]
        public async Task<ActionResult<Restaurant>> UpdateRestaurantPropertiesByID(int id, Restaurant newRestaurant)
        {
            Restaurant? restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found!");
            }
            if (newRestaurant.Name != "string" && newRestaurant.Name.Trim() != "")
            {
                restaurant.Name = newRestaurant.Name;
            }
            if (newRestaurant.Description != "string" && newRestaurant.Description.Trim() != "")
            {
                restaurant.Description = newRestaurant.Description;
            }
            if (newRestaurant.Label != "string" && newRestaurant.Label.Trim() != "")
            {
                restaurant.Label = newRestaurant.Label;
            }
            if (newRestaurant.City != "string" && newRestaurant.City.Trim() != "")
            {
                restaurant.City = newRestaurant.City;
            }
            if (newRestaurant.Street != "string" && newRestaurant.Street.Trim() != "")
            {
                restaurant.Street = newRestaurant.Street;
            }
            if (newRestaurant.HouseNumber != 0 )
            {
                restaurant.HouseNumber = newRestaurant.HouseNumber;
            }
            if (newRestaurant.PostCode != 0)
            {
                restaurant.PostCode = newRestaurant.PostCode;
            }
            if (newRestaurant.PhoneNumber != "string" && newRestaurant.PhoneNumber.Trim() != "")
            {
                restaurant.PhoneNumber = newRestaurant.PhoneNumber;
            }
            if (newRestaurant.OpeningHours != "string" && newRestaurant.OpeningHours.Trim() != "")
            {
                restaurant.OpeningHours = newRestaurant.OpeningHours;
            }
            this._context.SaveChanges();
            return Ok(restaurant);
        } 
    }
}
