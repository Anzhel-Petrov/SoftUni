﻿using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Data.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GenreNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();

}