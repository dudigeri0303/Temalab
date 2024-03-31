using BackendAPI.Controllers.Common;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers
{
    public class CategoryController : BaseEntityController
    {
        public CategoryController(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
