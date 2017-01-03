using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class TOAHController : Controller
    {
        // GET: Monitor
        public ActionResult Index()
        {
            MonitorRepository repo = new MonitorRepository();
            List<Monitor> model = repo.GetAllMonitors();
            return View(model);
        }
    }
}