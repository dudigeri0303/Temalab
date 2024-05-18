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
            try 
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId);
                if (userId != null && user != null)
                {
                    List<ReservationDto> reservationDots = new List<ReservationDto>();
                    List<Reservation> reservations = await this.crudOperator.DbContext.Reservations.Where(r => r.ReserverId == userId).ToListAsync();
                    foreach (var reservation in reservations)
                    {
                        Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(reservation.RestaurantId);
                        if (restaurant != null)
                        {
                            reservationDots.Add(new ReservationDto(reservation.Id, restaurant.Name, user.UserName, reservation.DateTime,
                                reservation.NumOfPeople, reservation.Lenght, reservation.Comment));
                        }
                    }
                    return Ok(reservationDots);
                }
                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("getReservationsByRestaurantId")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<List<ReservationDto>>> GetReservationsByRestaurantId(string restaurantId) 
        {
            List<Reservation> reservations = await this.crudOperator.GetMultipleRowsByForeignId<Reservation>(restaurantId, "RestaurantId");
            List<ReservationDto> reservationDtos = new List<ReservationDto>();
            foreach(var reservation in reservations) 
            {
                User? user = await this.userManager.FindByIdAsync(reservation.ReserverId);
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(reservation.RestaurantId);
                if(user !=  null && restaurant != null)
                {
                    reservationDtos.Add(new ReservationDto(reservation.Id, restaurant.Name, user.UserName, reservation.DateTime,
                        reservation.NumOfPeople, reservation.Lenght, reservation.Comment));
                }
            }
            return Ok(reservationDtos);
        }

        [Authorize(Roles = "Customer")]
        [HttpDelete("deleteReservationForLoggedUser/")]
        public async Task<ActionResult> DeleteReservationByIdForLoggedUser(string reservationId) 
        {
            try 
            {
                Reservation? reservation = await this.crudOperator.GetRowById<Reservation>(reservationId);
                Restaurant? reserstaurant = await this.crudOperator.GetRowById<Restaurant>(reservation.RestaurantId);
                //Ha lemondják a foglalást, akkor felszabadítjuk a megfelelő számú helyet
                reserstaurant!.NumOfFreeSeats += reservation.NumOfPeople;
                await this.crudOperator.DeleteRowById<Reservation>(reservationId);
                return Ok("Reservation deleted");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost("reserveTableForLoggedUser")]
        public async Task<ActionResult<CreateReservationDto>> ReserveTableForLoggedUser(CreateReservationDto reservationDto) 
        {
            try
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId);
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(reservationDto.restaurantId);    
                if(restaurant != null && user != null) 
                {
                    //Csak akkor van foglalás, ha van elég üres hely az étteremben
                    if (restaurant.NumOfFreeSeats >= reservationDto.numOfPeople) 
                    {
                        restaurant.NumOfFreeSeats -= reservationDto.numOfPeople;
                        Reservation reservation = new Reservation(user, restaurant, reservationDto.dateTime, reservationDto.numOfPeople, reservationDto.lenght, reservationDto.comment);
                        await this.crudOperator.InsertNewRow<Reservation>(reservation);
                        return Ok(reservationDto);
                    }
                    return BadRequest("There are not enough free seats in the restaurant for he reservation!");
                }
                return BadRequest("Something went wrong:(");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }
        #endregion
    }
}
