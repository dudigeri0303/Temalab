using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseEntityController<Review>
    {
        public ReviewController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<Review>> UpdateUserPropertiesByID(int id, Review updatedEntity)
        {
            return NotFound("Not yet implemented!");
        }
    }
}
