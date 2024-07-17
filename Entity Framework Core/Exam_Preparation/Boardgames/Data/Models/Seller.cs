using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Boardgames.Data.Models;

public class Seller
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;
    
    [Required] public string Website { get; set; } = null!;

    public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();


}