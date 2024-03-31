using BackendAPI.Models.EntityFrameworkModel.Common;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
            _dbContext = dbContext;
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
        public async Task DeleteUserById<T>(string id)
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
        public async Task UpdateUserPropertiesByID<T>(int id, T updatedEntity)
            where T : class
        {
            DbSet<T> dbSet = GetDbsetForGeneric<T>();
            T? entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                ((IEntityModelBase<T>)entity).updateEntity(updatedEntity);
                _dbContext.SaveChanges();
            }
        }
        #endregion
    }
}
