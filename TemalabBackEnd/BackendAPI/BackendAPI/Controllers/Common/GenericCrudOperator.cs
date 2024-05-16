using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers.Common
{
    public class GenericCrudOperator
    {
        private readonly DatabaseContext _dbContext;

        public DatabaseContext DbContext => _dbContext;
        public GenericCrudOperator(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        private DbSet<T> GetDbsetForGeneric<T>()
            where T : class
        {
            foreach (var kvp in _dbContext.EntityTables)
            {
                if (typeof(DbSet<T>).IsAssignableFrom(kvp.Value.GetType()))
                {
                    return (DbSet<T>)kvp.Value;
                }
            }
            return null;
        }
        #region GenericCrudOperations
        public async Task<List<T>> GetAllRows<T>()
            where T : class
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            List<T> entites = await dbSet.ToListAsync();
            return entites;
        }
        public async Task<T?> GetRowById<T>(string id)
            where T : class
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            T? entity = await dbSet.FindAsync(id);
            return entity;
        }
        public async Task<List<T>> GetMultipleRowsByForeignId<T>(string id, string propertyName)
            where T : class
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            List<T> entities = await dbSet
                .Where(entity => EF.Property<string>(entity, propertyName) == id)
                .ToListAsync();
            return entities;
        }
        public async Task DeleteRowById<T>(string id)
            where T : class
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            T? entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
        }
        public async Task InsertNewRow<T>(T newEntity)
            where T : class
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            try
            {
                await dbSet.AddAsync(newEntity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task<T> GetRowByForeignId<T>(string foreignId, string propertyName)
            where T : class
        
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            return await dbSet.Where(entity => EF.Property<string>(entity, propertyName) == foreignId).FirstOrDefaultAsync(); 
        }
        public void SaveDatabaseChanges() 
        {
            _dbContext.SaveChanges();
        }
        public void UpdateRow<T>(T entity)
            where T : class
        {
            this._dbContext.Update(entity);
            this._dbContext.SaveChanges();
        }
        #endregion
    }
}
