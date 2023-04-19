using Microsoft.EntityFrameworkCore;
using PmSystem.Domain.Entities;

namespace PmSystem.Infrastructure.Data
{
    public class CustomerRepository : Repository<Customer>
    {
        private readonly PmSystemDbContext _dbContext;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(PmSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Customer>();
        }

        public async override Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbSet.Include(i => i.CustomerItems).Where(i => i.Status == true).ToListAsync();
        }
    }
}
