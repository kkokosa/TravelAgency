using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLearn1.Services
{
    public class GetTripsRequest
    {
        public int MinNumberOfDays;
        public int MaxNumberOfDays;
    }

    public class GetTripsResponse
    {
        public bool Succees;
        public List<TripDesc> Trips;
    }

    public class GetToursRequest
    {
        public List<int> TripIDs;
    }

    public class GetToursResponse
    {
        public bool Succees;
        public List<TourDesc> Tours;
    }

    public class TripDesc
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfDays { get; set; }
    }

    public class TourDesc
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Cost { get; set; }
        public bool SpecialOffer { get; set; }
    }
}