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
    
    public partial class CustomizedTour
    {
        public int BookingId { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public Nullable<int> Adults { get; set; }
        public Nullable<int> Child { get; set; }
        public Nullable<int> Baby { get; set; }
        public Nullable<int> Seniors { get; set; }
        public string AccommodationStyle { get; set; }
        public string ModesOfTransportation { get; set; }
        public string PreferredType { get; set; }
        public string MealsIncluded { get; set; }
        public string WhereVisit { get; set; }
        public string MoreMessages { get; set; }
        public string Payment { get; set; }
        public string WhereHear { get; set; }
        public Nullable<bool> Remove { get; set; }
    }
}