using BackendAPI.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseEntityController
    {
        public MenuController(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
