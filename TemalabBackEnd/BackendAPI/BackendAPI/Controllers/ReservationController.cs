using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
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
        [Authorize(Roles = "Customer")]
        [HttpGet("getReservationsForLoggedInUser/")]
        public async Task<ActionResult<List<ReservationDto>>> GetReservationsByLoggedInUser() 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                List<ReservationDto> reservationModels = new List<ReservationDto>();
                List<Reservation> reservations = await this.crudOperator.DbContext.Reservations.Where(r => r.ReserverId == userId).ToListAsync();
                foreach(var reservation in reservations)
                {
                    Table? table = await this.crudOperator.GetRowById<Table>(reservation.TableId);
                    if (table != null)
                    {
                        Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(table.RestaurantId);
                        reservationModels.Add(new ReservationDto(reservation.Id, restaurant.Name, table.Id, reservation.EndDate.ToString()));
                        await Console.Out.WriteLineAsync(reservation.EndDate.ToString());
                    }
                    else { Console.WriteLine("Table not found"); }
                }
                return Ok(reservationModels);
            }
            return NotFound("User not found");
        }

        [Authorize(Roles = "Customer")]
        [HttpDelete("deleteReservationForLoggedUser/")]
        public async Task<ActionResult> DeleteReservationByIdForLoggedUser(string reservationId) 
        {
            try 
            {
                //Nem biztos hogy jó. Elvileg a foglalás törlésekor a foglalt asztal IsReserved property-jét false ra állítja.
                Reservation? reservation = await this.crudOperator.GetRowById<Reservation>(reservationId);
                Table? table = await this.crudOperator.GetRowById<Table>(reservation.TableId);
                if (table != null) 
                {
                    table.IsReserved = false;
                    await this.crudOperator.DeleteRowById<Reservation>(reservationId);
                    return Ok("Reservation deleted");
                }
                return BadRequest("Could not found the table for the reservation:(");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //TODO: foglalás leadása api endpoint

        [HttpPost("reserveTableForLoggedUser")]
        public async Task<ActionResult<Reservation>> ReserveTableForLoggedUser(string tableId) 
        {
            try
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId);
                Table? table = await this.crudOperator.GetRowById<Table>(tableId);
                if(table != null && user != null)
                {
                    table.IsReserved = true;
                    Reservation reservation = new Reservation(user, table, DateTime.Now);
                    await this.crudOperator.InsertNewRow<Reservation>(reservation);
                    return Ok(reservation);
                }
                return BadRequest("Table or User was null!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }
        #endregion
    }
}
