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

        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("getOwnerByRestaurantID/{id}")]
        public async Task<ActionResult<Owner>> GetOwnerByRestaurantId(int id) 
        {
            Owner owner = await this._context.Owners.Where(o => o.RestaurantId == id).FirstOrDefaultAsync();
            if(owner == null) 
            {
                NotFound("Restaurant not found");
            }
            return Ok(owner);
        }

        /*
        [HttpGet("getOwnerByRestaurantName/{string}")]
        public async Task<ActionResult<Owner>> GetOwnerByRestaurantName(string name)
        {
            
            Owner owner = await this._context.Owners.Where(o => o.RestaurantId == id).FirstOrDefaultAsync();
            if (owner == null)
            {
                NotFound("");
            }
            return Ok(owner);
        } 
         */
    }
}
