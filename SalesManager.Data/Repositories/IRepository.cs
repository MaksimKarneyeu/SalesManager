using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> DeleteAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        TEntity Add(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity updated, Guid key);
    }
}
    