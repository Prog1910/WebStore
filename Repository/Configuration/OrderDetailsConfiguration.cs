using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.HasKey(od => new { od.OrderId, od.ProductId });

        builder.HasData(
        [
            new OrderDetails { OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderDetails { OrderId = 1, ProductId = 2, Quantity = 2 },
            new OrderDetails { OrderId = 2, ProductId = 3, Quantity = 3 }
        ]);
    }
}