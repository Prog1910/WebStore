﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Order
{
    [Column("OrderId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer is required.")]
    public string? Customer { get; set; }

    public ICollection<OrderDetails>? OrderDetails { get; set; }
}