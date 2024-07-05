using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MusicHub.Data.Models;

public class Writer
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(20)] public string Name { get; set; } = null!;
    public string? Pseudonym { get; set; }
    public virtual ICollection<Song>? Songs { get; set; }
}