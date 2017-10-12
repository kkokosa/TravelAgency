using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLearn1.ViewModels
{
    public class HomepageViewModel
    {
        public IEnumerable<WebLearn1.ViewModels.TripViewModel> Trips;
        public SpecialOffersViewModel SpecialOffers;
    }
}