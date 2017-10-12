using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebLearn1.Models;

namespace WebLearn1.Services
{
    public class TravelServices : ITravelServices
    {
        static TravelServices()
        {
            Mapper.CreateMap<Trip, TripDesc>();
            Mapper.CreateMap<Tour, TourDesc>();
        }

        public GetTripsResponse GetTrips(GetTripsRequest request)
        {
            using (var db = new TripsOfferDbContext())
            {
                var trips = db.Trips.Where(trip => trip.NumberOfDays >= request.MinNumberOfDays && trip.NumberOfDays <= request.MaxNumberOfDays)
                                    .ToList();
                var response = new GetTripsResponse()
                {
                    Succees = true,
                    Trips = trips.Select(trip => Mapper.Map<TripDesc>(trip))
                                 .ToList()
                };
                return response;
            }
        }

        public GetToursResponse GetTours(GetToursRequest request)
        {
            using (var db = new TripsOfferDbContext())
            {
                db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                var trips = db.Trips.Where(tour => request.TripIDs.Contains(tour.ID))
                                    .SelectMany(trip => trip.Tours)
                                    .ToList();
                var response = new GetToursResponse()
                {
                    Succees = true,
                    Tours = trips.Select(tour => Mapper.Map<TourDesc>(tour))
                                 .ToList()
                };
                return response;
            }
        }         
    }
}
