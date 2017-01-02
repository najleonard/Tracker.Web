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
        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        public ActionResult Table()
        {
            var settings = Properties.Settings.Default;
            var formData = HttpContext.Request.Form;
    
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                DtResponse response  = new Editor(db, "LLInventoryView3", new []{"OrderId"})
                    .Model<LLInventoryView3>()
                    .Process(Request.Form)
                    .Data();
    
                return Json(response);
            }
        }
    }    
}