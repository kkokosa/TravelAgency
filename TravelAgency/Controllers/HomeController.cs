using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebLearn1.Models;
using WebLearn1.ViewModels;

namespace WebLearn1.Controllers
{
    public class HomeController : Controller
    {
        private TripsOfferDbContext db = new TripsOfferDbContext();
        
        static HomeController()
        {
            Mapper.CreateMap<Trip, TripViewModel>()
                  .ForMember(dest => dest.LeadPhotoSource, opt => opt.MapFrom(src => GetImageAddress(src.Photos.OrderBy(_ => Guid.NewGuid()).First().FilePath)))
                  .ForMember(dest => dest.PhotoSources, opt => opt.MapFrom(src => src.Photos.Select(p => GetImageAddress(p.FilePath)).ToList()))
                  .AfterMap((src, dest) => dest.Tours.ForEach(tvm => tvm.EndTime = tvm.StartTime.AddDays(src.NumberOfDays)));
            Mapper.CreateMap<Tour, TourViewModel>();
        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            var trips = db.Trips.ToList();
            var viewModel = new HomepageViewModel()
            {
                Trips = trips.Select(trip => Mapper.Map<TripViewModel>(trip))
                                 .ToList(),
                SpecialOffers = new SpecialOffersViewModel()
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static string GetImageAddress(string filename)
        {
            return string.Format("~/Data/Images/Small/{0}", filename);
        }
    }
}