using ProductApp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ProductApp.Domain;

public class Product : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to zero.")]
    public int Quantity { get; set; }
}
