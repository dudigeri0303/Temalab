using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : BaseEntityController<Reservation>
    {
        public ReservationController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<Reservation>> UpdateUserPropertiesByID(int id, Reservation updatedEntity)
        {
            return NotFound("Not yet implemented!");
        }
    }
}
