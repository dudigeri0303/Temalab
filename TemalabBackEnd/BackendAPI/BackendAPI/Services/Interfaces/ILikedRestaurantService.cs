using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Services.Interfaces
{
    public interface ILikedRestaurantService
    {
        Task<ActionResult> DeleteLikedRestaurantByIdForLoggedUser(string likedRestaurantId, GenericCrudOperator crudOperator);
        Task<ActionResult<List<LikedRestaurantDto>>> GetLikedRestaurantByLoggedInUser(string userId, GenericCrudOperator crudOperator);

    }
}
