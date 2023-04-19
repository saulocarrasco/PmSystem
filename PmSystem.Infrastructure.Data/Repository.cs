using Microsoft.EntityFrameworkCore;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityModel, new()
    {
        private readonly PmSystemDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(PmSystemDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(i=>i.Status == true).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(i=>i.Id == id);
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.Status = true;
            entity.CreatedAt = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Status = true;
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.Status = false;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
