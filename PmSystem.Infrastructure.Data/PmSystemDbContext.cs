using Microsoft.EntityFrameworkCore;
using PmSystem.Domain.Entities;


namespace PmSystem.Infrastructure.Data
{
    public class PmSystemDbContext : DbContext
    {
        public PmSystemDbContext(DbContextOptions<PmSystemDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
