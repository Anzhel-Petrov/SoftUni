using System.ComponentModel.DataAnnotations;
using NetPay.Data.Models.Enums;
using static NetPay.Data.DataConstraints;

namespace NetPay.DataProcessor.ImportDtos;

public class ImportExpenseDto
{
    [Required]
    [MinLength(ExpenseNameMinLength)]
    [MaxLength(ExpenseNameMaxLength)]
    public string ExpenseName { get; set; } = null!;

    [Required]
    [Range((double)ExpenseAmountMinRange, (double)ExpenseAmountMaxRange)]
    public decimal Amount { get; set; }

    [Required]
    public string DueDate { get; set; } = null!;

    [Required]
    public string PaymentStatus { get; set; } = null!;

    public int HouseholdId { get; set; }

    public int ServiceId { get; set; }
}