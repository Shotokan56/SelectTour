using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Areas.GUI.Models;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class BookedSelectViewModel
    {
        public SelectTourBooked objData { get; set; }
        public TotalTable TotalTable { get; set; }
    }

    public class ListBookedSelectViewModel
    {
        public List<SelectTourBooked> lstData { get; set; }
        public int TotalPage { get; set; }
    }
}