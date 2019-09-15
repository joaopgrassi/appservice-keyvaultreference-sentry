using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }
    }
}
