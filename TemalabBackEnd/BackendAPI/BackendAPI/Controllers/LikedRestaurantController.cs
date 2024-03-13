using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedRestaurantController : BaseEntityController<LikedRestaurant>
    {
        public LikedRestaurantController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<LikedRestaurant>> UpdateUserPropertiesByID(int id, LikedRestaurant updatedEntity)
        {
            return NotFound("Not yet implemented!");
        }
    }
}
