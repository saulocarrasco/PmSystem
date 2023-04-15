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
                        .HasOne(p => p.Customer)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
