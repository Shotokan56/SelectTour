using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.GUI.Models
{
    public class EnquireView
    {
        public PackageTour PackageTour { get; set; }
        public List<ReferenceValue> ListClass { get; set; }
        public List<ReferenceValue> ListCountry { get; set; }
    }

    //public class PackageTourBook
    //{
    //    public DateTime DepartureDate { get; set; }
    //}
}