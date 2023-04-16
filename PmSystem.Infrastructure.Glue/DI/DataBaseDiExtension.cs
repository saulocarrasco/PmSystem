using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PmSystem.Infrastructure.Data;

namespace PmSystem.Infrastructure.Glue.DI
{
    public static class DataBaseDiExtension
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlDataConnectionString = configuration.GetConnectionString("SqlDataConnectionString");

            services.AddDbContext<PmSystemDbContext>(options =>
            {
                options.UseSqlServer(sqlDataConnectionString, m => m.MigrationsAssembly("PmSystem.Infrastructure.Data"));
            });
        }
    }
}
