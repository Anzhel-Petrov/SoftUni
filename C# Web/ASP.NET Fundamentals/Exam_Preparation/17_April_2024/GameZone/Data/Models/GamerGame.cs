using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Data.Models;

public class GamerGame
{
    public int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; } = null!;

    public string GamerId { get; set; } = null!;

    [ForeignKey(nameof(GamerId))]
    public IdentityUser Gamer { get; set; } = null!;
}