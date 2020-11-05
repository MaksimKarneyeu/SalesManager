using SalesManager.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SalesManager.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected SalesManagerContext context { get; private set; }

        public Repository(SalesManagerContext context)
        {
            this.context = context;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {   
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync() => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(Guid id) => await context.Set<TEntity>().FindAsync(id);

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);           
            context.SaveChanges();            
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity updated, Guid key)
        {
            if (updated == null)
                return null;
            
            TEntity existing = await context.Set<TEntity>().FindAsync(key);
            if (existing != null)
            {                 
                context.Entry(existing).CurrentValues.SetValues(updated);
                await context.SaveChangesAsync();
            }
            return existing;
        }       
    }
}
