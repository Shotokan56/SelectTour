using System.Collections.Generic;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class SelectTourViewModel : SelectTour
    {
        public List<ReferenceValue> LstTourStyle { get; set; }

        public List<ReferenceValue> LstAreas { get; set; }

        public string Message { get; set; }

    }

    public class SelectTourListViewModel
    {
        public List<SelectTour> LstSelectTour { get; set; }
        public int TotalPage { get; set; }
    }
}