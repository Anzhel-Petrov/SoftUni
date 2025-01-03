using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(TitleMaxLength);

        builder
            .Property(m => m.Genre)
            .IsRequired()
            .HasMaxLength(GenreMaxLength);
    }
}