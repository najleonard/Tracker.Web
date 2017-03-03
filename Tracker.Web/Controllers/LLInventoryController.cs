using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DataTables;
using System.Net.Http;
using Tracker.Web.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace Tracker.Web.Controllers
{  
    public class LLInventoryController : Controller
    {
        // GET: Monitor
        public ActionResult Index()
        {
            return View();
        }
    }
}
