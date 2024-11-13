using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Models;

public class GameAddViewModel
{
    [Required]
    [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength)]
    public string Title { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    [Required]
    [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required] 
    public string ReleasedOn { get; set; } = DateTime.Now.ToString(GameReleasedOnFormat);

    [Required]
    public int GenreId { get; set; }

    public IEnumerable<GameGenreViewModel>? Genres { get; set; } = new List<GameGenreViewModel>();
}