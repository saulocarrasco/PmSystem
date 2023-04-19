using Microsoft.EntityFrameworkCore;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;
using System.Linq.Expressions;

namespace PmSystem.Infrastructure.Data
{
    public class ReportRepository<TEntity> : IReportRepository<TEntity> where TEntity : CustomerItem, new()
    {
        private readonly PmSystemDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public ReportRepository(PmSystemDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Include(i=>i.Customer).Include(i=>i.Product).Where(expression).ToListAsync();
        }
    }
}
