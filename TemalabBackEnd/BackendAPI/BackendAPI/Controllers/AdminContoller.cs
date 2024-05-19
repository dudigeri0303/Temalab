using BackendAPI.Controllers.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminContoller : BaseEntityController
    {
        public AdminContoller([FromServices] DatabaseContext dbContext, [FromServices] UserManager<User> userManager) : base(dbContext, userManager)
        {
        }
    }
}
