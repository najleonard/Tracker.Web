using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    // public class TOAHController : Controller
    // {
    //     // GET: Inventory
    //     public ActionResult Index()
    //     {
    //         LLInventoryRepository3 repo = new LLInventoryRepository3();
    //         var model = repo.GetTOAHList();
    //         return View(model);
    //     }
    // }
    public class TOAHController : ApiController
   {
  //      [HttpGet, HttpPost, Route("api/upload")]
        public IHttpActionResult Index()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                DtResponse response = new Editor( db, 'ItemOrder' )
                    .Model<ItemOrder>()
                    .Process( Request.Form )
                    .Data();
 
                return Json(response);
            }
        }
    }
}
