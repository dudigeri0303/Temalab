using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        public async Task<ActionResult> DeleteReservationByIdForLoggedUser(string reservationId, GenericCrudOperator crudOperator)
        {
            try
            {
                Reservation? reservation = await crudOperator.GetRowById<Reservation>(reservationId);
                Restaurant? reserstaurant = await crudOperator.GetRowById<Restaurant>(reservation!.RestaurantId);
                //Ha lemondják a foglalást, akkor felszabadítjuk a megfelelő számú helyet
                reserstaurant!.NumOfFreeSeats += reservation.NumOfPeople;
                await crudOperator.DeleteRowById<Reservation>(reservationId);
                return new OkObjectResult("Reservation deleted");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult<List<ReservationDto>>> GetReservationsByLoggedInUser(User user, GenericCrudOperator crudOperator)
        {
            try
            {
                if (user != null)
                {
                    List<ReservationDto> reservationDots = new List<ReservationDto>();
                    List<Reservation> reservations = await crudOperator.DbContext.Reservations.Where(r => r.ReserverId == user.Id).ToListAsync();
                    foreach (var reservation in reservations)
                    {
                        Restaurant? restaurant = await crudOperator.GetRowById<Restaurant>(reservation.RestaurantId);
                        if (restaurant != null)
                        {
                            reservationDots.Add(new ReservationDto(reservation.Id, restaurant.Name, user.UserName, user.PhoneNumber, user.Email, reservation.DateTime,
                                reservation.NumOfPeople, reservation.Lenght, reservation.Comment));
                        }
                    }
                    return new OkObjectResult(reservationDots);
                }
                return new NotFoundObjectResult("User not found");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
