using Microsoft.EntityFrameworkCore;
using RazorPagessingers.Models;

namespace RazorPagessingers.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagessingersContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagessingersContext>>()))
            {
                if (context == null || context.singers == null)
                {
                    throw new ArgumentNullException("Null RazorPagessingersContext");
                }

                // Look for any singerss.
                if (context.singers.Any())
                {
                    return;   // DB has been seeded
                }

                context.singers.AddRange(
                    new singers
                    {
                        Name = "Arijit Singh",
                        BirthDate = DateTime.Parse("1982-6-15"),
                        PopularAlbum = "Rabata",
                        NumberOfAwards = 4
                    },

                    new singers
                    {
                        Name = "Atif Aslam",
                        BirthDate = DateTime.Parse("1979-9-29"),
                        PopularAlbum = "Yaariya",
                        NumberOfAwards = 6
                    },

                    new singers
                    {
                        Name = "Kishor Kumar",
                        BirthDate = DateTime.Parse("1956-7-07"),
                        PopularAlbum = "Sholey",
                        NumberOfAwards = 12
                    },

                    new singers
                    {
                        Name = "A P Dhilon",
                        BirthDate = DateTime.Parse("1989-02-03"),
                        PopularAlbum = "Kendi",
                        NumberOfAwards = 10
                    },

                    new singers
                    {
                        Name = "Baadshaah",
                        BirthDate = DateTime.Parse("1988-01-19"),
                        PopularAlbum = "RaOne",
                        NumberOfAwards = 7
                    }
                );
                context.SaveChanges();
            }
        }
    }
}