using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers
{
    public abstract class BaseEntityController<ControllerClass> : ControllerBase where ControllerClass : class
    {
        protected readonly DatabaseContext _dbContext;

        protected BaseEntityController(DatabaseContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        #region GenericCrudOperations

        [HttpGet("getAllRows/")]
        public async Task<ActionResult<List<ControllerClass>>> GetAllRows()
        {
            DbSet<ControllerClass> dbSet = this._dbContext.GetDbSet<ControllerClass>();
            List <ControllerClass> entites = await dbSet.ToListAsync();
            return Ok(entites);
        }

        [HttpGet("searchByID/{id}")]
        public async Task<ActionResult<ControllerClass>> GetRowById(int id) 
        {
            DbSet<ControllerClass> dbSet = this._dbContext.GetDbSet<ControllerClass>();
            ControllerClass? entity = await dbSet.FindAsync(id);
            if (entity == null) 
            {
                return NotFound("Entity not found!");
            }
            return Ok(entity);
        }

        [HttpDelete("deleteByID/{id}")]
        public async Task<ActionResult<IEntityModelBase>> DeleteUserById(int id) 
        {
            DbSet<ControllerClass> dbSet = this._dbContext.GetDbSet<ControllerClass>();
            ControllerClass? entity = await dbSet.FindAsync(id);
            if (entity == null) 
            {
                return NotFound("Entity not found so it can not be deleted!");
            }
            dbSet.Remove(entity);
            this._dbContext.SaveChanges();
            return Ok(entity);
        }

        [HttpPost("insertNewRow/{newEntity}")]
        public async Task<ActionResult> InsertNewRow(ControllerClass newEntity) 
        {
            DbSet<ControllerClass> dbSet = this._dbContext.GetDbSet<ControllerClass>();
            try
            {
                dbSet.Add(newEntity);
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(newEntity);
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public abstract Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, ControllerClass updatedEntity);

        #endregion
    }
}
