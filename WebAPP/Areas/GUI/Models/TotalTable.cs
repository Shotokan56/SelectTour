using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WebAPP.Areas.GUI.Models
{
    public class TotalRow
    {
        public string Level { get; set; }
        public string People { get; set; }
        public string TourId { get; set; }
        public string TourName { get; set;}
        public double Price { get; set; }
        public double SingleSupplement { get; set; }
    }


    public class TotalTable
    {
        public IEnumerable<TotalRow> DataRows { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceSingle { get; set; }
        public string StrResultTable { get; set; }
    }
}