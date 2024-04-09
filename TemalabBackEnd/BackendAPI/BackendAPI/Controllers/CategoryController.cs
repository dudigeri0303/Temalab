using BackendAPI.Controllers.Common;
using Microsoft.AspNetCore.Identity;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class CategoryController : BaseEntityController
    {
        public CategoryController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }
    }
}
