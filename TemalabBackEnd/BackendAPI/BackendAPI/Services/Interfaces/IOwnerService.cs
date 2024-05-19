using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<ActionResult<List<RestaurantDataDto>>> ListRestaurantsByOwner(string userId, GenericCrudOperator crudOperator);
    }
}
