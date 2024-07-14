using System.ComponentModel.DataAnnotations;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models;

public class Product
{
    [Key] public int Id { get; set; }
    [MinLength(9)] [MaxLength(30)] public string Name { get; set; } = null!;
    [Required] [Range(5.00, 1000.00)] public decimal Price { get; set; }
    [Required] public CategoryType CategoryType { get; set; }
    public virtual ICollection<ProductClient>? ProductsClients { get; set; }
}