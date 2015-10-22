using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;

namespace WebAPP.Areas.GUI.Models
{
    public class HomeViewModel
    {
        public List<PackageTour> LstPackageTour { get; set; }
        public List<SelectTour> LstSelectTour { get; set; }
        public UserViewModel User { get; set; }
    }
}