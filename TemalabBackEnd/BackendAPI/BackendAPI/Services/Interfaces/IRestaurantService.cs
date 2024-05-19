using BackendAPI.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<ActionResult> DeleteRestaurantById(string restaurantId, GenericCrudOperator crudOperator);
    }
}
