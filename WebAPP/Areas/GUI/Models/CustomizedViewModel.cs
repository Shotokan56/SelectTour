using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.GUI.Models
{
    public class CustomizedViewModel:CustomizedTour
    {
        public List<ReferenceValue> ListNationality { get; set; }
        public List<ReferenceValue> ListPayment { get; set; }
        public List<ReferenceValue> ListAccommodation { get; set; }
        public List<ReferenceValue> ListTransportation { get; set; }
    }
}