using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Boardgames.Data.Models.Enums;

namespace Boardgames.Data.Models;

public class Boardgame
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(20)]
    [MaxLength(20)]
    public string Name { get; set; } = null!;
    [Required]
    [Range(1.00, 10.00)]
    public double Rating { get; set; }
    [Required]
    [Range(2018, 2023)]
    public int YearPublished { get; set; }
    [Required]
    public CategoryType CategoryType { get; set; }
    [Required] public string Mechanics { get; set; } = null!;
    public int CreatorId { get; set; }
    [ForeignKey(nameof(CreatorId))]
    public Creator Creator { get; set; } = null!;
    public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
}