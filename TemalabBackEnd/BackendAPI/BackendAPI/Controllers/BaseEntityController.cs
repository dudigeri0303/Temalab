using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public abstract class BaseEntityController : ControllerBase
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

        //HTTP POST
        [HttpPost("insertNewRow/{newEntity}")]
        public abstract Task<ActionResult> InsertNewRow(IEntityModelBase newEntity);

    }
}
