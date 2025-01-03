using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
            
        }

        public CinemaDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
    }
}
