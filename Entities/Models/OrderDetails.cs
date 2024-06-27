using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class OrderDetails
{
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public int? Quantity { get; set; }

    public Product? Product { get; set; }
    public Order? Order { get; set; }
}