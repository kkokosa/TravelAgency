using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using WebLearn1.Models;
using WebLearn1.ViewModels;

namespace WebLearn1.Controllers
{
    public class SpecialOffersController : Controller
    {
        public ActionResult GetOffers(string categoryId, int limit)
        {
            Thread.Sleep(1000);

            using (TripsOfferDbContext db = new TripsOfferDbContext())
            {
                var viewModel = new SpecialOffersViewModel()
                {
                    Offers = db.Trips.SelectMany(t => t.Tours, (trip, tour) => new OfferViewModel()
                    {
                        Name = trip.Name,
                        Cost = tour.Cost,
                        StartTime = tour.StartTime,
                    })
                    .Take(limit)
                    .ToList()
                };
                return PartialView("SpecialOffers", viewModel);
            }
            
        }
    }
}
