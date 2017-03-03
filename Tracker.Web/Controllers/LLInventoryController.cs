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
    // public class LLInventoryController : Controller
    // {
    //     // GET: Inventory
    //     public ActionResult Index(string sortOrder)
    //     {
    //         LLInventoryRepository repo = new LLInventoryRepository();
    //         var model = repo.GetCurrentLLInventory(sortOrder);
    //         return View(model);
    //     }
    // }

    [RoutePrefix("api/inventory")]
    public class LLInventoryController : ApiController
    {   
        [HttpGet]
        [HttpPost]
        [Route("getdata")]
        public IHttpActionResult Table()
        {
            var settings = Properties.Settings.Default;
            var request = HttpContext.Current.Request;
    
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                DtResponse response  = new Editor(db, "Inventory")
                    .Model<LLInventoryView2>()
                                        .Process(request)
                    .Data();
                    
                return Json(response);
            }
        }
    }    
}