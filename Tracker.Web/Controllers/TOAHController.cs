using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;
using DataTables;

namespace Tracker.Web.Controllers
{
    public class TOAHController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            LLInventoryRepository3 repo = new LLInventoryRepository3();
            var model = repo.GetTOAHList();
            return View(model);
        }
    }
    
}