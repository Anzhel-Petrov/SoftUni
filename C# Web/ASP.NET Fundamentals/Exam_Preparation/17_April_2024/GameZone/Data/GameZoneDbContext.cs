﻿using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GamerGame>()
                .HasKey(gg => new {gg.GamerId, gg.GameId});

            builder.Entity<Game>()
                .HasOne(g => g.Publisher)
                .WithMany()
                .HasForeignKey(p => p.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            builder
                .Entity<Genre>()
                .HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Fighting" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Racing" },
                new Genre { Id = 6, Name = "Strategy" });
        }

        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<GamerGame> GamersGames { get; set; } = null!;
    }
}
