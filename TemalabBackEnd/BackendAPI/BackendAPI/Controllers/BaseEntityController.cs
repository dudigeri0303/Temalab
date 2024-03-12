using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers
{
    public abstract class BaseEntityController<ControllerClass> : ControllerBase
    {
        protected readonly DatabaseContext _dbContext;

        protected BaseEntityController(DatabaseContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        [HttpGet("getAllRows/")]
        public abstract Task<ActionResult<List<IEntityModelBase>>> GetAllRows();

        [HttpGet("searchByID/{id}")]
        public abstract Task<ActionResult<IEntityModelBase>> GetRowById(int id);

        [HttpDelete("deleteByID/{id}")]
        public abstract Task<ActionResult<IEntityModelBase>> DeleteUserById(int id);

        [HttpPost("insertNewRow/{newEntity}")]
        public abstract Task<ActionResult> InsertNewRow(ControllerClass newEntity);

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public abstract Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, ControllerClass updatedEntity);
    }
}
