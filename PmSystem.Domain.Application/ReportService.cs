using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;
using System.Linq.Expressions;

namespace PmSystem.Domain.Application
{
    public class ReportService : IReportService<CustomerItem>
    {
        private readonly IReportRepository<CustomerItem> _reportRepository;

        public ReportService(IReportRepository<CustomerItem> reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<CustomerItem>> GetAsync(int id)
        {
            Expression<Func<CustomerItem, bool>> expression = i => i.Id == id;

            return await _reportRepository.GetAsync(expression);
        }
    }
}
