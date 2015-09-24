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
        public string SelectTourName { get; set; }
        public string SelectTourDuration { get; set; }
        public string SelectTourDestination { get; set; }
        public double SelectTourPrice { get; set; }
    }
}