using BackendAPI.Controllers.Common;
using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : BaseEntityController
    {
        public ReservationController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        #region UniqueApiCalls
        [HttpGet("getReservationsForLoggedInUser/"), Authorize]
        public async Task<ActionResult<List<Reservation>>> GetReservationsByLoggedInUser() 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<Reservation> reservations = await this.crudOperator.DbContext.Reservations.Where(r => r.ReserverId == userId).ToListAsync();
                return Ok(reservations);
            }
            return NotFound("User not found");
        }

        #endregion
    }
}
