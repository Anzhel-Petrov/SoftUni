using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ProductNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(ProductDescriptionMaxLength)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range((double)ProductPriceMinRange, (double)ProductPriceMaxRange)]
    [Precision(6, 2)]
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    [Required]
    public string SellerId { get; set; } = string.Empty!;

    [ForeignKey(nameof(SellerId))]
    public IdentityUser Seller { get; set; } = null!;

    [Required]
    public DateTime AddedOn { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    [Required]
    public bool IsDeleted { get; set; }

    public virtual ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
}