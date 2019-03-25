using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public static class CommonConstants
    {
        public static string CHECK_LOGIN = "CHECK_LOGIN";
        public static string Domain_Images = ConfigurationManager.AppSettings["images"]; 
        public static string Domain_Web = ConfigurationManager.AppSettings["domain"];

        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";
        public static string CurrentCulture { set; get; }

    }
}