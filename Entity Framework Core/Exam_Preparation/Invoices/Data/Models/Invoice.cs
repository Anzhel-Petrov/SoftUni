using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models;

public class Invoice
{
    [Key] public int Id { get; set; }
    [Range(1000000000,1500000000)] public int Number { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))] public virtual Client? Client { get; set; }
}