using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;

namespace BackendAPI.Controllers
{
    public abstract class BaseEntityController<EntityClass> : ControllerBase where EntityClass : class
    {
        protected readonly DatabaseContext _dbContext;

        protected BaseEntityController(DatabaseContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        #region GenericCrudOperations

        [HttpGet("getAllRows/")]
        public async Task<ActionResult<List<EntityClass>>> GetAllRows()
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
            List <EntityClass> entites = await dbSet.ToListAsync();
            return Ok(entites);
        }

        [HttpGet("searchByID/{id}")]
        public async Task<ActionResult<EntityClass>> GetRowById(int id) 
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
            EntityClass? entity = await dbSet.FindAsync(id);
            if (entity == null) 
            {
                return NotFound("Entity not found!");
            }
            return Ok(entity);
        }

        [HttpDelete("deleteByID/{id}")]
        public async Task<ActionResult<EntityClass>> DeleteUserById(int id) 
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
            EntityClass? entity = await dbSet.FindAsync(id);
            if (entity == null) 
            {
                return NotFound("Entity not found so it can not be deleted!");
            }
            dbSet.Remove(entity);
            this._dbContext.SaveChanges();
            return Ok(entity);
        }

        [HttpPost("insertNewRow/{newEntity}")]
        public async Task<ActionResult> InsertNewRow(EntityClass newEntity) 
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
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
        public abstract Task<ActionResult<EntityClass>> UpdateUserPropertiesByID(int id, EntityClass updatedEntity);

        #endregion
    }
}
