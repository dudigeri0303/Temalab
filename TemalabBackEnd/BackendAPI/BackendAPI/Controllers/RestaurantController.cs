using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : BaseEntityController<Restaurant>
    {

        public RestaurantController(DatabaseContext context) : base(context)
        {
        }
        #region UniqueOperations

        /*[HttpPost("createNewRestaurantWithOwner/")]
        public async void CreateRestaurantWithOwner() 
        {


        }*/
        #endregion
    }
}
