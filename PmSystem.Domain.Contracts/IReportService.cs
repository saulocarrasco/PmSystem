using System.Linq.Expressions;

namespace PmSystem.Domain.Contracts
{
    public interface IReportService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(int id);
    }
}
