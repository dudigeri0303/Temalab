using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("getAllRows/")]
        public override async Task<ActionResult<List<IEntityModelBase>>> GetAllRows()
        {
            List<Owner> owners = await this._dbContext.Owners.ToListAsync();
            return Ok(owners);
        }

        [HttpGet("searchByID/{id}")]
        public override async Task<ActionResult<IEntityModelBase>> GetRowById(int id) 
        {

            Owner? user = await this._dbContext.Owners.FindAsync(id);
            if (user == null)
            {
                return NotFound("Owner not found!");
            }
            return Ok(user);
        }

        [HttpDelete("deleteByID/{id}")]
        public override async Task<ActionResult<IEntityModelBase>> DeleteUserById(int id) 
        {
            //Owner ownerToDelete = this.GetOwnerById(id).Result;
            Owner? owner = await this._dbContext.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound("Owner not fount, you cant delete it");
            }
            this._dbContext.Owners.Remove(owner);
            this._dbContext.SaveChanges();
            return Ok(owner);
        }

        [HttpPost("insertNewRow/{newEntity}")]
        public override async Task<ActionResult> InsertNewRow(Owner newEntity) 
        {
            try
            {
                this._dbContext.Owners.Add(newEntity);
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(newEntity);
        }

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
