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
    internal class JoinInventoryProducts : EditorModel
    {
        public class Inventory : EditorModel
        {
            public int Id { get; set; }

            public string Product_sku { get; set; }

            public int Size { get; set; }

            public string Color { get; set; }

            public string Extra { get; set; }

            public string Location { get; set; }

            public string rfid_tag { get; set; }
        }

        public class Products : EditorModel
        {
            public string name { get; set; }
            public string sku { get; set; }
            public string type { get; set; }
        }
        
    }
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
                    .Model<JoinInventoryProducts>()
                    .LeftJoin("Products", "Inventory.Product_sku", "=", "Products.sku")
                    .Process(request)
                    .Data();
                    
                return Json(response);
            }
        }
    }    
}