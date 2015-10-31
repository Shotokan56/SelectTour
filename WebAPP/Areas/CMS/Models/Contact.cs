using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class ContactListViewModel
    {
        public List<Contact> LstContact { get; set; }
        public int TotalPage { get; set; }
    }
}