using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : BaseEntityController<Restaurant>
    {

        public RestaurantController(DatabaseContext context) : base(context)
        {
        }
        #region UniqueOperations

        [HttpGet("getOwnerByRestaurantID/{id}")]
        public async Task<ActionResult<Owner>> GetOwnerByRestaurantId(string id)
        {
            Owner? owner = await this._dbContext.Owners.Where(o => o.RestaurantId == id).FirstOrDefaultAsync();
            if (owner == null)
            {
                NotFound("Restaurant not found");
            }
            return Ok(owner);
        }

        [HttpGet("getRestaurantByOwnerName/{name}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantByOwnerName(string name)
        {
            List<string> ownerIds = this._dbContext.Users.Where(u => u.UserName == name).Select(u => u.Id).ToList();
            List<Owner> owners = new List<Owner>();
            foreach (string id in ownerIds)
            {
                foreach (var owner in this._dbContext.Owners)
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
                foreach (var restaurant in this._dbContext.Restaurants)
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

        #endregion
    }
}
