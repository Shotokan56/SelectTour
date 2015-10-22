using System.Collections.Generic;
using WebAPP.Areas.CMS.Models;
using WebAPP.Models;

namespace WebAPP.Areas.GUI.Models
{
    public class SelectTourViewModel
    {
        public List<SelectTour> ListSelectTour { get; set; }
        public UserViewModel User { get; set; }
    }
}