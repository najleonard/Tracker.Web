using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult RedirectToAspx()
        {
            return Redirect("/Login.aspx");
        }
        public ActionResult Index()
        {
            if (User == null || User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToAspx();
            }
            else
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}