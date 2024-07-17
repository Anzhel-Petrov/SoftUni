using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ExportDto.JSON;

public class ProductsWithMostClientsDto
{
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public CategoryType Category { get; set; }
    public ExportClientDto[] Clients { get; set; }
}