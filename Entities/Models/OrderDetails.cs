using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class OrderDetails
{
    public int Quantity { get; set; }

    [Key]
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [Key]
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}