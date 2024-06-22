﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
        => builder.HasData(
        [
            new Order { Id = 1, Customer = "John Doe" },
            new Order { Id = 2, Customer = "Jane Smith" }
        ]);
}