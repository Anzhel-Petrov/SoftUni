using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Data.Models;

public class ProductClient
{
    public string ClientId { get; set; } = string.Empty;

    [ForeignKey(nameof(ClientId))]
    public virtual IdentityUser Client { get; set; } = null!;

    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Game { get; set; } = null!;
}