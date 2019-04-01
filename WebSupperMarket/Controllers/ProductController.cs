using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSupperMarket.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult mat_ong_tracybee()
        {
            return View();
        }
        public ActionResult collagen_vinh_hoan()
        {
            return View();
        }
    }
}