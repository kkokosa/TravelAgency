namespace WebLearn1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebLearn1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebLearn1.Models.TripsOfferDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebLearn1.Models.TripDbContext";
        }

        protected override void Seed(WebLearn1.Models.TripsOfferDbContext context)
        {
            ConfigurationHelper.SeedCountry(context, "Poland", 3, 6);
            ConfigurationHelper.SeedCountry(context, "Egypt", 2, 5);
            ConfigurationHelper.SeedCountry(context, "France", 2, 5);
        }
    }
}
