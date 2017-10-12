using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLearn1.ViewModels
{
    public class SpecialOffersViewModel
    {
        public List<OfferViewModel> Offers;
    }

    public class OfferViewModel
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Cost { get; set; }
    }
}