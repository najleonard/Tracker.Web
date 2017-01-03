using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;
using DataTables;

namespace Tracker.Web.Controllers
{
    internal class JoinOrderClient
    {
        public class myOrder
        {
            public int Id { get; set; }

            public int ClientId { get; set; }

            public int Shipped { get; set; }

            public string ShippedDate { get; set; }

            public string RequestItems { get; set; }

            public string RequestDate { get; set; }

            public int InventoryItem1 { get; set; }

            public int InventoryItem2 { get; set; }

            public int InventoryItem3 { get; set; }

            public int InventoryItem4 { get; set; }

        }

        public class myClient
        {
            public int Id { get; set; }  //<-------JUST ADDED
            public string email { get; set; }
        }
    }

 
    public class TOAHController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        // GET: Inventory
        public ActionResult Index()
        {
            LLInventoryRepository3 repo = new LLInventoryRepository3();
            var model = repo.GetTOAHList();
            return View(model);
        }

        public ActionResult Table()
        {
            var settings = Properties.Settings.Default;
            var formData = HttpContext.Request.Form;
    
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                DtResponse response  = new Editor(db, "Order", "Order.Id")
                    .Model<JoinOrderClient>()
                    .Process(formData)
                    .Data();
    
                return Json(response,JsonRequestBehavior.AllowGet);
            }
        }
    }   
} 

