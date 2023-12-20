using System;
using Specification.Data.Models;

namespace Specification.Data
{
    public static class PrepDb
    {
        public static void PrepData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
            }
        }

        private static void SeedData(ApplicationDbContext context)
        {

            Console.WriteLine("---> Seeding Data");
            context.Movies.AddRange(
               new Movie
            {
                Id = 1,
                Name = "The Amazing Spider-Man",
                ReleaseDate = new DateTime(2012, 07, 03),
                MpaaRating = MpaaRating.PG13,
                Genre = "Adventure",
                Rating = 7
            },
            new Movie
            {
                Id = 2,
                Name = "Beauty and the Beast",
                ReleaseDate = new DateTime(2017, 03, 17),
                MpaaRating = MpaaRating.PG13,
                Genre = "Family",
                Rating = 7
            },
            new Movie
            {
                Id = 3,
                Name = "The Secret Life of Pets",
                ReleaseDate = new DateTime(2016, 07, 08),
                MpaaRating = MpaaRating.G,
                Genre = "Adventure",
                Rating = 7
            },
            new Movie
            {
                Id = 4,
                Name = "The Jungle Book",
                ReleaseDate = new DateTime(2016, 04, 15),
                MpaaRating = MpaaRating.PG,
                Genre = "Fantasy",
                Rating = 7
            },
            new Movie
            {
                Id = 5,
                Name = "Split",
                ReleaseDate = new DateTime(2017, 01, 20),
                MpaaRating = MpaaRating.PG13,
                Genre = "Horror",
                Rating = 7
            },
            new Movie
            {
                Id = 6,
                Name = "The Mummy",
                ReleaseDate = new DateTime(2017, 06, 09),
                MpaaRating = MpaaRating.R,
                Genre = "Action",
                Rating = 7
            }
            );

            context.SaveChanges();

        }
    }
}
