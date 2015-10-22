using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Common;
using WebAPP.Models;

namespace WebAPP.Areas.CMS.Models
{
    public class UserViewModel:User
    {
            //Add new
            
            public string Message { get; set; }
            public bool RememberMe { get; set; }

            public int LanguaeId { get; set; }
            public UserViewModel()
            {
                RememberMe = false;
                //LanguaeId = (int)Languages.EngLish;
                LanguaeId = int.Parse(ConfigurationManager.AppSettings["Default_Languae"]);// default is English
            }
    }

    public class UserListView
    {
            public List<User> LstUser { get; set; }
            public int TotalPage { get; set; }
    }

    public class UserEditView:User
    {
        public List<SelectListItem> LstRoles { get; set; }
    }
}