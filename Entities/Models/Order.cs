using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Order
{
    [Column("OrderId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "CustomerId is required.")]
    public int? CustomerId { get; set; }

    public ICollection<OrderDetails>? OrderDetails { get; set; }
}