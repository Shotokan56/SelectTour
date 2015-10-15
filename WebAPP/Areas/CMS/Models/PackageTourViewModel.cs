using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class PackageTourViewModel : PackageTour
    {
        public List<ReferenceValue> LstTourStyle { get; set; }

        public string Message { get; set; }

    }

    public class PackageTourListViewModel
    {
        public List<PackageTour> LstPackageTour {get;set;}
        public int TotalPage { get; set; }
    }
}