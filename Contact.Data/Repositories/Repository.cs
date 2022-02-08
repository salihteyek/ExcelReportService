using Contact.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RiseAssessmentDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(RiseAssessmentDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByUUIDAsync(Guid UUID)
        {
            return await _dbSet.FindAsync(UUID);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => {
                _dbSet.Remove(entity);
            });
        }
    }
}
