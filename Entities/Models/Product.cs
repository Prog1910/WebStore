using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Product
{
    [Column("ProductId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name can't be empty.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Price can't be lower than zero.")]
    public double? Price { get; set; }
}