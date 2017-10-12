using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLearn1.ViewModels
{
    public class TripViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LeadPhotoSource { get; set; }
        public List<string> PhotoSources { get; set; }
        public List<TourViewModel> Tours { get; set; }
    }

    public class TourViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool SpecialOffer { get; set; }
        public decimal Cost { get; set; }

        public string PeriodText
        {
            get
            {
                return string.Format("{0:dd.MM} - {1:dd.MM.yyyy}", StartTime, EndTime);
            }
        }

        public string CostText
        {
            get
            {
                return string.Format("{0} PLN", Cost);
            }
        }   
    }
}