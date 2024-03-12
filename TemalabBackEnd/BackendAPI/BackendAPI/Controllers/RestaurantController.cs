using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Http;
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

        #region CrudOperations

        [HttpGet("getAllRows/")]
        public override async Task<ActionResult<List<IEntityModelBase>>> GetAllRows() 
        {
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("searchByID/{id}")]
        public override async Task<ActionResult<IEntityModelBase>> GetRowById(int id) 
        {
            Restaurant? restaurant = await this._dbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound("User not found!");
            }
            return Ok(restaurant);
        }

        [HttpDelete("deleteByID/{id}")]
        public override async Task<ActionResult<IEntityModelBase>> DeleteUserById(int id) 
        {
            //Restaurant restaurantToDelete = this.GetRestaurantById(id).Result;
            Restaurant? restaurant = await this._dbContext.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound("Restaurant not fount, you cant delete it");
            }
            this._dbContext.Restaurants.Remove(restaurant);
            this._dbContext.SaveChanges();
            return Ok(restaurant);
        }

        [HttpPost("insertNewRow/{newEntity}")]
        public override async Task<ActionResult> InsertNewRow(Restaurant newEntity) 
        {
            try
            {
                this._dbContext.Restaurants.Add(newEntity);
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(newEntity);
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, Restaurant updatedEntity) 
        {
            Restaurant updatedRestaurant = updatedEntity;
            Restaurant? restaurant = await this._dbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found!");
            }
            if (updatedRestaurant.Name != "string" && updatedRestaurant.Name.Trim() != "")
            {
                restaurant.Name = updatedRestaurant.Name;
            }
            if (updatedRestaurant.Description != "string" && updatedRestaurant.Description.Trim() != "")
            {
                restaurant.Description = updatedRestaurant.Description;
            }
            if (updatedRestaurant.Label != "string" && updatedRestaurant.Label.Trim() != "")
            {
                restaurant.Label = updatedRestaurant.Label;
            }
            if (updatedRestaurant.City != "string" && updatedRestaurant.City.Trim() != "")
            {
                restaurant.City = updatedRestaurant.City;
            }
            if (updatedRestaurant.Street != "string" && updatedRestaurant.Street.Trim() != "")
            {
                restaurant.Street = updatedRestaurant.Street;
            }
            if (updatedRestaurant.HouseNumber != 0)
            {
                restaurant.HouseNumber = updatedRestaurant.HouseNumber;
            }
            if (updatedRestaurant.PostCode != 0)
            {
                restaurant.PostCode = updatedRestaurant.PostCode;
            }
            if (updatedRestaurant.PhoneNumber != "string" && updatedRestaurant.PhoneNumber.Trim() != "")
            {
                restaurant.PhoneNumber = updatedRestaurant.PhoneNumber;
            }
            if (updatedRestaurant.OpeningHours != "string" && updatedRestaurant.OpeningHours.Trim() != "")
            {
                restaurant.OpeningHours = updatedRestaurant.OpeningHours;
            }
            this._dbContext.SaveChanges();
            return Ok(restaurant);
        }


        #endregion

        #region UniqueOperations

        [HttpGet("getOwnerByRestaurantID/{id}")]
        public async Task<ActionResult<Owner>> GetOwnerByRestaurantId(int id)
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
            List<int> ownerIds = this._dbContext.Users.Where(u => u.UserName == name).Select(u => u.Id).ToList();
            List<Owner> owners = new List<Owner>();
            foreach (int id in ownerIds)
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
