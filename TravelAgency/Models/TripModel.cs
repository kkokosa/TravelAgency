using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebLearn1.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfDays { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }

    public class Tour
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Cost { get; set; }
        public bool SpecialOffer { get; set; }
    }

    public class Photo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }

    public class TripsOfferDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}