using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
        => builder.HasData(
        [
            new Product { Id = 1, Name = "Laptop", Price = 999.99d },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99d },
            new Product { Id = 3, Name = "Tablet", Price = 299.99d }
        ]);
}