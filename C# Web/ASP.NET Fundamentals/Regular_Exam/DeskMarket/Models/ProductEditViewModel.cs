using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models;

public class ProductEditViewModel
{
    [Required]
    [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [Range((double)ProductPriceMinRange, (double)ProductPriceMaxRange)]
    [Precision(6, 2)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; } = string.Empty;

    [Required]
    [RegexStringValidator(@"^\d{4}-\d{2}-\d{2}$")]
    public string AddedOn { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    [Required]
    public string SellerId { get; set; } = string.Empty;

    public virtual IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
}