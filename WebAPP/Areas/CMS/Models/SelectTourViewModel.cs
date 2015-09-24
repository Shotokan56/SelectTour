using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPP.Areas.CMS.Models
{
    public class SelectTourViewModel
    {
        [Key]
        public int SelectTourId { get; set; }

        [Display(Name = "Name")]
        public string SelectTourName { get; set; }

        [Display(Name = "Duration")]
        public string SelectTourDuration { get; set; }

        [Display(Name = "Destination")]
        public string SelectTourDestination { get; set; }

        [Display(Name = "Price")]
        public double SelectTourPrice { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Agency 1")]
        public string Agency1 { get; set; }

        [Display(Name = "Agency 2")]
        public string Agency2 { get; set; }

        [Display(Name = "Agency 3")]
        public string Agency3 { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class SelectTourDetailViewModel:TravelerInfo
    {
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}