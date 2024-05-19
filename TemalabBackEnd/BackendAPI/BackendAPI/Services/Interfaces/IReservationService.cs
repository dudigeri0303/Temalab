using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ActionResult> DeleteReservationByIdForLoggedUser(string reservationId, GenericCrudOperator crudOperator);
        Task<ActionResult<List<ReservationDto>>> GetReservationsByLoggedInUser(User user, GenericCrudOperator crudOperator);
    }
}
