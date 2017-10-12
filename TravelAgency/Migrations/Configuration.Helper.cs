namespace WebLearn1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebLearn1.Models;

    public class ConfigurationHelper
    {
        /*
            ConfigurationHelper.SeedCountry(context, "Poland", 3, 6);
            ConfigurationHelper.SeedCountry(context, "Egypt", 2, 5);
            ConfigurationHelper.SeedCountry(context, "France", 2, 5);
         */
        public static void SeedCountry(WebLearn1.Models.TripsOfferDbContext context, string countryName, int numberOfTrips, int numberOfPhotos)
        {
            var rand = new Random();

            // Seed photos
            var photos = Enumerable.Range(1, numberOfPhotos)
                                   .Select(i => new Photo()
                                   {
                                       Title = string.Format("{0} - {1} is so nice", i, countryName),
                                       Description = string.Format("As you see, {0} is beatifull", countryName),
                                       FilePath = string.Format("{0}{1}.jpg", countryName.ToLowerInvariant(), i),
                                       Trips = new List<Trip>()
                                   })
                                   .ToArray();

            // Seed trips (with random number of photosca)
            var trips = Enumerable.Range(1, numberOfTrips)
                                  .Select(i =>
                                  {
                                      var numberOdDays = rand.Next(3, 7);
                                      var baseConst = rand.Next(10, 25) * 100m;
                                      var startDate = DateTime.Now.AddDays(2.0);
                                      return new Trip()
                                      {
                                          Name = string.Format("{0} in {1} days", countryName, numberOdDays),
                                          Description = string.Format("Visit {0} for {1} days and be stunned how interesting it is!", countryName, numberOdDays),
                                          NumberOfDays = numberOdDays,
                                          Photos = photos.OrderBy(_ => Guid.NewGuid())
                                                         .Take(rand.Next(3, numberOfPhotos + 1))
                                                         .ToList(),
                                          Tours = Enumerable.Range(1, 7)
                                                            .Select(t => new Tour()
                                                            {
                                                                Cost = baseConst * (1m + 0.05m * t),
                                                                StartTime = startDate.AddDays(t * (numberOdDays + 2)),
                                                                SpecialOffer = rand.NextDouble() >= 0.80
                                                            })
                                                            .ToList()
                                      };
                                  })
                                  .ToArray();

            // Update database
            context.Trips.AddOrUpdate(t => t.Name, trips);
            context.Photos.AddOrUpdate(p => p.FilePath, photos);
        }
    }
}