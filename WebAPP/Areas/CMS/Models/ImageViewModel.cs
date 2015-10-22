using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class ImageViewModel
    {
        public List<ReferenceValue> LstCategory { get; set; }
        public List<Slide> LstImage { get; set; } 
    }
}