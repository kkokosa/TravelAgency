using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebLearn1.Models;
using WebLearn1.ViewModels;

namespace WebLearn1.Controllers
{
    public class TripsController : Controller
    {
        static TripsController()
        {
            Mapper.CreateMap<Trip, TripViewModel>()
                  .ForMember(dest => dest.LeadPhotoSource, opt => opt.MapFrom(src => GetImageAddress(src.Photos.OrderBy(_ => Guid.NewGuid()).First().FilePath)))
                  .ForMember(dest => dest.PhotoSources, opt => opt.MapFrom(src => src.Photos.Select(p => GetImageAddress(p.FilePath)).ToList()))
                  .AfterMap((src, dest) => dest.Tours.ForEach(tvm => tvm.EndTime = tvm.StartTime.AddDays(src.NumberOfDays)));
            Mapper.CreateMap<Tour, TourViewModel>();
        }

        public TripsController()
        {
        }

        // GET: Trips
        public ActionResult Index()
        {
            using (var db = new TripsOfferDbContext())
            {
                var trips = db.Trips.ToList();
                var viewModel = trips.Select(trip => Mapper.Map<TripViewModel>(trip))
                                     .ToList();

                return View(viewModel);
            }
        }

        private static string GetImageAddress(string filename)
        {
            //Task.Run(() => Thread.Sleep(1000)).ConfigureAwait(continueOnCapturedContext: false);
            return string.Format("~/Data/Images/Small/{0}", filename);
        }
    }
}