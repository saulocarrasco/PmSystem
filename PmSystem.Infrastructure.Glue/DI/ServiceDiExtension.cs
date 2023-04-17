using Microsoft.Extensions.DependencyInjection;
using PmSystem.Domain.Application;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Infrastructure.Glue.DI
{
    public static class ServiceDiExtension
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<Product>), typeof(ProductService));
            services.AddScoped(typeof(IService<Customer>), typeof(CustomerService));
        }
    }
}
