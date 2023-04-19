using Microsoft.Extensions.DependencyInjection;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;
using PmSystem.Infrastructure.Data;

namespace PmSystem.Infrastructure.Glue.DI
{
    public static class RepositoryDiExtension
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Product>), typeof(Repository<Product>));
            services.AddScoped(typeof(IRepository<Customer>), typeof(CustomerRepository));
            services.AddScoped(typeof(IRepository<CustomerItem>), typeof(CustomerItemsRepository));
            services.AddScoped(typeof(IReportRepository<CustomerItem>), typeof(ReportRepository<CustomerItem>));
        }
    }
}
