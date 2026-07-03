using Microsoft.EntityFrameworkCore;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired();
        }
    }
}