using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByUUIDAsync(Guid UUID);
    }
}
