using System.ComponentModel.DataAnnotations;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ImportDto;

public class ImportProductDto
{
    [MinLength(9)] [MaxLength(30)] public string Name { get; set; } = null!;
    [Required] [Range(5.00, 1000.00)] public decimal Price { get; set; }
    [EnumDataType(typeof(CategoryType))]
    [Required] public CategoryType CategoryType { get; set; }
    public int[] Clients { get; set; } = null!;
}