﻿
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;

public class Creator
{
    [Key]
    public int Id { get; set; }

    [Required] [MinLength(2)] [MaxLength(7)] public string FirstName { get; set; } = null!;
    [Required] [MinLength(2)] [MaxLength(7)] public string LastName { get; set; } = null!;

    public ICollection<Boardgame> Boardgames { get; set; } = new HashSet<Boardgame>();

}