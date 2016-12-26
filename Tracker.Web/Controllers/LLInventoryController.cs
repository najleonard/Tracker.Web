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
        public ActionResult Index(string sortOrder)
        {
            LLInventoryRepository repo = new LLInventoryRepository();
            var model = repo.GetCurrentLLInventory(sortOrder);
            return View(model);
            
        }
    }
}