using Microsoft.EntityFrameworkCore;
using PmSystem.Domain.Entities;

namespace PmSystem.Infrastructure.Data
{
    public class CustomerItemsRepository : Repository<CustomerItem>
    {
        public CustomerItemsRepository(PmSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<CustomerItem>> GetAllAsync()
        {
            return await _dbSet.Include(i => i.Product).Include(i => i.Customer).Where(i => i.Status == true).ToListAsync();
        }
    }
}
