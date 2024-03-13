using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminContoller : BaseEntityController<Admin>
    {
        public AdminContoller(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public override Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, Admin updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
