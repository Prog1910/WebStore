using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
    }

    public DbSet<Order>? Orders { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<OrderDetails>? OrdersDetails { get; set; }
}