using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetPay.Data.Models.Enums;
using static NetPay.Data.DataConstraints;

namespace NetPay.Data.Models;

public class Expense
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ExpenseNameMaxLength)]
    public string ExpenseName { get; set; } = null!;

    [Required]
    [Range((double)ExpenseAmountMinRange, (double)ExpenseAmountMaxRange)]
    public decimal Amount { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public PaymentStatus PaymentStatus { get; set; }

    public int HouseholdId { get; set; }

    [ForeignKey(nameof(HouseholdId))]
    public virtual Household Household { get; set; } = null!;

    public int ServiceId { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public virtual Service Service { get; set; } = null!;
}