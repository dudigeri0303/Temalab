using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers.Common
{
    public abstract class BaseEntityController : ControllerBase
    {
        protected GenericCrudOperator crudOperator;
        protected readonly UserManager<User> userManager;

        public BaseEntityController(DatabaseContext dbContext, UserManager<User> userManager) 
        {
            this.crudOperator = new GenericCrudOperator(dbContext);
            this.userManager = userManager;
        }
    }
}
