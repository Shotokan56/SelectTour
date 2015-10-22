using System.Collections.Generic;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;

namespace WebAPP.Areas.GUI.Models
{
    public class PackageTourViewModel
    {
        public List<PackageTour> LstPackageTour { get; set; }
        public UserViewModel User { get; set; }
        public int TotalPage { get; set; }
    }
}