using Contact.Core.Repositories;
using Contact.Core.Services;
using Contact.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByUUIDAsync(Guid UUID)
        {
            return await _repository.GetByUUIDAsync(UUID);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _repository.RemoveAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
