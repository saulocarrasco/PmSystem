using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PmSystem.Domain.Contracts
{
    public interface IReportRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}
