using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers.Common
{
    public abstract class BaseEntityController : ControllerBase
    {
        protected GenericCrudOperator crudOperator;
        public BaseEntityController(DatabaseContext dbContext) 
        {
            this.crudOperator = new GenericCrudOperator(dbContext);
        }
    }
}
