using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPP.Areas.CMS.Models
{
    public class PackageTourViewModel
    {
        [Key]
        public int PackageTourId { get; set; }

        [Display(Name = "Name")]
        public string PackageTourName { get; set; }

        [Display(Name = "Duration")]
        public string PackageTourDuration { get; set; }

        [Display(Name = "Destination")]
        public string PackageTourDestination { get; set; }

        [Display(Name = "Price")]
        public double PackageTourPrice { get; set; }

        [Display(Name = "Route")]
        public string Route { get; set; }

        [Display(Name = "Date")]
        public string Date { get; set; }

        [Display(Name = "Activity Level")]
        public string ActivityLevel { get; set; }

        [Display(Name = "Start/End")]
        public string StartEnd { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Agency 1")]
        public string Agency1 { get; set; }

        [Display(Name = "Agency 2")]
        public string Agency2 { get; set; }

        [Display(Name = "Agency 3")]
        public string Agency3 { get; set; }
    }

    public class PackageTourBookedViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Departure Date")]
        public string DepartureDate { get; set; }

        [Display(Name = "Tour Class")]
        public string TourClass { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
    }


    public class PackageTourBookedDetailViewModel: TravelerInfo
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Length")]
        public string Length { get; set; }

        [Display(Name = "Route")]
        public string Route { get; set; }

        [Display(Name = "Departure Date")]
        public string DepartureDate { get; set; }

        [Display(Name = "Tour Class")]
        public string TourClass { get; set; }

        [Display(Name = "Billing Option")]
        public string BillingOption { get; set; }

        [Display(Name = "Adults")]
        public int Adults { get; set; }

        [Display(Name = "Childs")]
        public int Childs { get; set; }

        [Display(Name = "Baby")]
        public int Baby { get; set; }

        [Display(Name = "Seniors")]
        public int Seniors { get; set; }

        [Display(Name = "Additional plans or ideas")]
        public int AdditionalPlansOrIdeas { get; set; }
    }
}