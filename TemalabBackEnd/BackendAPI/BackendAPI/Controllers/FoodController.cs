using BackendAPI.Controllers.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : BaseEntityController
    {
        public FoodController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }
    }
}
