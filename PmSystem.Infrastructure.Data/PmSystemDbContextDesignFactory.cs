using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PmSystem.Infrastructure.Data
{
    public class PmSystemDbContextDesignFactory : IDesignTimeDbContextFactory<PmSystemDbContext>
    {
        public PmSystemDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<PmSystemDbContext>();


            var connectionString = configuration.GetConnectionString("SqlDataConnectionString");
            builder.UseSqlServer(connectionString);

            return new PmSystemDbContext(builder.Options);
        }
    }
}
