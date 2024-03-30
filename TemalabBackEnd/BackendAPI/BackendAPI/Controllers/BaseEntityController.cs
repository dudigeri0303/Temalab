using BackendAPI.Models.EntityFrameworkModel.Common;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

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

        [Authorize]
        [HttpGet("getAllRows/")]
        public async Task<ActionResult<List<EntityClass>>> GetAllRows()
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
            List <EntityClass> entites = await dbSet.ToListAsync();
            return Ok(entites);
        }

        [HttpGet("searchByID/{id}")]
        public async Task<ActionResult<EntityClass>> GetRowById(string id) 
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
        public async Task<ActionResult<EntityClass>> DeleteUserById(string id) 
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

        [HttpPost("insertNewRow")]
        public async Task<ActionResult> InsertNewRow(EntityClass newEntity) 
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
            try
            {
                if (typeof(User).IsAssignableFrom(typeof(EntityClass)))
                {
                    (newEntity as User).PasswordHash = Argon2.Hash((newEntity as User).PasswordHash);
                }
                dbSet.Add(newEntity);
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(newEntity);
        }

        [HttpPut("updateEntityPropertiesByID/{id}")]
        public async Task<ActionResult<EntityClass>> UpdateUserPropertiesByID(int id, EntityClass updatedEntity) 
        {
            DbSet<EntityClass> dbSet = this._dbContext.GetDbSet<EntityClass>();
            EntityClass? entity = await dbSet.FindAsync(id);
            if (entity == null) 
            {
                return NotFound("Entity not found");
            }
            ((IEntityModelBase<EntityClass>)entity).updateEntity(updatedEntity);
            this._dbContext.SaveChanges();
            return Ok(entity);
        }
        #endregion
    }
}
