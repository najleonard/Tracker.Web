using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class LLInventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            LLInventoryRepository repo = new LLInventoryRepository();
            var model = repo.GetCurrentLLInventory();
            return View(model);
            //return "hello world";
        }
    }
}