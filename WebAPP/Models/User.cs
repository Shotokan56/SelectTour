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
    
    public partial class User
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Nullable<bool> Lock { get; set; }
        public string Roles { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Nullable<bool> Remove { get; set; }
        public int User_Id { get; set; }
    }
}
