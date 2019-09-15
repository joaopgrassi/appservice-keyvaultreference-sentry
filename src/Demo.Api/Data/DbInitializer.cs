using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Demo.Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(MoviesDbContext context, ILogger logger)
        {
            context.Database.Migrate();

            // DB has been seeded
            if (context.Movies.Any())
            {
                return;
            }

            logger.LogInformation("Going to seed the database...");
            var movies = new Movie[]
            {
                 new Movie{ Title = "Ghostbusters" },
                 new Movie{ Title = "Gladiator" },
                 new Movie{ Title = "Avatar" },
                 new Movie{ Title = "The Lion King" },
                 new Movie{ Title = "The Dark Knight" },
                 new Movie{ Title = "Eternal Sunshine of the Spotless Mind" },
                 new Movie{ Title = "The Big Lebowski" },

            };
            context.AddRange(movies);
            context.SaveChanges();

            logger.LogInformation("Db seeded. All systems go!");
        }
    }
}
