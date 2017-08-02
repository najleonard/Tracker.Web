using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class ReadyOrdersController : Controller
    {
        private trackerwebdbEntities2 db = new trackerwebdbEntities2();

        // GET: UpdateInventoryLocations
        public ActionResult Index()
        {
            return View(db.TOAH_sizeRelevant8.ToList());
        }

    }
}
