using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class TableController : BaseEntityController<Table>
    {
        public TableController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public override Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, Table updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
