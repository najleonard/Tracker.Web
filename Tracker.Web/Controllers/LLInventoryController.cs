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


namespace Tracker.Web.Controllers
{  
    [Authorize]
    public class LLInventoryController : Controller
    {
        // GET: Monitor
        public ActionResult Index()
        {
            return View();
        }
    }
}
