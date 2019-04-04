using Admin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            LoginModel Rember = (LoginModel)Session[CommonConstants.CHECK_LOGIN];
            if (Rember != null)
            {
                Sys_User employee = (Sys_User)Session[CommonConstants.USER_SESSION];
                return View(employee);

            }
            else
                return RedirectToAction("Index", "/Login");
        }

        public ActionResult ManageImages()
        {
            return View();
        }
    }
}