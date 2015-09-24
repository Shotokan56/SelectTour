using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPP.Areas.CMS.Models
{
    public class CustomizedTourListViewModel
    {
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Arrival Date")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }
    }
}