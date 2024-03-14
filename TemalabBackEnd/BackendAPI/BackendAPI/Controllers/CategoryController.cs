using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class CategoryController : BaseEntityController<Category>
    {
        public CategoryController(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
