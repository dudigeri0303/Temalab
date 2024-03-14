using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : BaseEntityController<Food>
    {
        public FoodController(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
