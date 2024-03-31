using BackendAPI.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : BaseEntityController
    {
        public FoodController(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
