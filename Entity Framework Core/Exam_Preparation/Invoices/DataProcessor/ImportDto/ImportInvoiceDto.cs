using System.ComponentModel.DataAnnotations;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ImportDto;

public class ImportInvoiceDto
{
    [Range(1000000000,1500000000)] public int Number { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    [EnumDataType(typeof(CurrencyType))]
    public CurrencyType CurrencyType { get; set; }
    public int ClientId { get; set; }
}