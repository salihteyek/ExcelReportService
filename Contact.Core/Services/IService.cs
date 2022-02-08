using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByUUIDAsync(Guid UUID);
    }
}
