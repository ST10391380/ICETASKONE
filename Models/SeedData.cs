using Microsoft.EntityFrameworkCore;
using ICETASKONE.Data;
using ICETASKONE.Migrations;

namespace ICETASKONE.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ICETASKONEContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ICETASKONEContext>>()))
            {
                if (context == null || context.RapMusic == null)
                {
                    throw new ArgumentNullException(null);
                }

                // Look for any rap songs.
                if (context.RapMusic.Any())
                {
                    return;   // DB has been seeded
                }

                context.RapMusic.AddRange(
                    new RapMusic
                    {
                        Title = "The Mint",
                        ReleaseYear = 2018,
                        Genre = "Abstract Hip-Hop",
                        Artist = "Earl Sweatshirt"
                    },

                    new RapMusic
                    {
                        Title = "JFK",
                        ReleaseYear = 2023,
                        Genre = "Trap Metal",
                        Artist = "Pranav.wav"
                    },

                    new RapMusic
                    {
                        Title = "M3tamorphisis",
                        ReleaseYear = 2020,
                        Genre = "Rage",
                        Artist = "Playboi Carti",
                    }

                    
                );
                context.SaveChanges();
            }
        }
}
    }