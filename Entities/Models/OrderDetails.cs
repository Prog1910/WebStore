using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class OrderDetails
{
    [Column("OrderDetailsId")]
    public int Id { get; set; }

    public int Quantity { get; set; }

    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}