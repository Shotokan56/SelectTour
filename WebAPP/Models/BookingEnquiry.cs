//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingEnquiry
    {
        public int BookId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> PackageTourId { get; set; }
        public Nullable<int> SelectTourId { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public Nullable<int> TourClass { get; set; }
        public Nullable<int> Adults { get; set; }
        public string Baby0_2 { get; set; }
        public Nullable<int> Child2_11 { get; set; }
        public Nullable<int> Seniors { get; set; }
        public string BillingOptions { get; set; }
        public string AdditionalPlans { get; set; }
        public string WhereHear { get; set; }
        public Nullable<bool> Remove { get; set; }
    }
}
