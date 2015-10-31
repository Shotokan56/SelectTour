using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class CustomizedTourListViewModel
    {
        public List<CustomizedTour> LstCustomizedTour { get; set; }
        public int TotalPage { get; set; }
    }
}