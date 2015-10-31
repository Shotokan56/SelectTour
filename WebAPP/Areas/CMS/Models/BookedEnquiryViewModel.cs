using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class BookedEnquiryViewModel
    {
            public List<BookingEnquiry> LstBookingEnquiry { get; set; }
            public int TotalPage { get; set; }
    }

    public class BookedEnquiryDetailViewModel
    {
        public BookingEnquiry ObjEnquiry { get; set; }
        public PackageTour PackageTour { get; set; }
    }

   
}