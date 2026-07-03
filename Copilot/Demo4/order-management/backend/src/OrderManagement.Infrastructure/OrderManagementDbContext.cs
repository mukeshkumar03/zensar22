using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure;

public class OrderManagementDbContext : DbContext
{
    public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(b =>
        {
            b.HasKey(c => c.Id);
            b.Property(c => c.Email).IsRequired();
            b.Property(c => c.FirstName).IsRequired();
            b.Property(c => c.LastName).IsRequired();
        });

        modelBuilder.Entity<Order>(b =>
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Total).HasColumnType("decimal(18,2)");
            b.HasMany(o => o.Items).WithOne().HasForeignKey("OrderId");
        });

        modelBuilder.Entity<OrderItem>(b =>
        {
            b.HasKey(oi => oi.Id);
            b.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Payment>(b =>
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Amount).HasColumnType("decimal(18,2)");
        });
    }
}