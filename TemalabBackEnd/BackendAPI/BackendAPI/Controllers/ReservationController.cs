using BackendAPI.Controllers.Common;
using BackendAPI.Models.ModelsForApiCalls;
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
        public ReservationController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        #region UniqueApiCalls
        [Authorize]
        [HttpGet("getReservationsForLoggedInUser/")]
        public async Task<ActionResult<List<ReservationModel>>> GetReservationsByLoggedInUser() 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<ReservationModel> reservationModels = new List<ReservationModel>();
                List<Reservation> reservations = await this.crudOperator.DbContext.Reservations.Where(r => r.ReserverId == userId).ToListAsync();
                Console.WriteLine(reservations.Count);
                foreach(var reservation in reservations)
                {
                    Table? table = await this.crudOperator.GetRowById<Table>(reservation.TableId);
                    if (table != null)
                    {
                        Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(table.RestaurantId);
                        reservationModels.Add(new ReservationModel
                        {
                            Id = reservation.Id,
                            RestaurantName = restaurant.Name,
                            TableId = table.Id,
                            EndDate = reservation.EndDate.ToString()
                        });
                        await Console.Out.WriteLineAsync(reservation.EndDate.ToString());
                    }
                    else { Console.WriteLine("Table not found"); }
                }
                return Ok(reservationModels);
            }
            return NotFound("User not found");
        }

        [Authorize]
        [HttpDelete("deleteReservationForLoggedUser/")]
        public async Task<ActionResult> DeleteReservationByIdForLoggedUser(string reservationId) 
        {
            try 
            {
                await this.crudOperator.DeleteRowById<Reservation>(reservationId);
                return Ok("Reservation deleted");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //TODO: foglalás leadása api endpoint

        #endregion
    }
}
