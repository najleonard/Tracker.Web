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
    internal class JoinOrderClient : EditorModel
    {
        public class Order : EditorModel
        {
            public int Id { get; set; }

            public int ClientId { get; set; }

            public string Date { get; set; }

            public int Shipped { get; set; }

            public string ShippedDate { get; set; }

            public string RequestItems { get; set; }

            public string RequestDate { get; set; }

            public int StreetSize { get; set; }

            public int InventoryItem1 { get; set; }

            public int InventoryItem2 { get; set; }

            public int InventoryItem3 { get; set; }

            public int InventoryItem4 { get; set; }
            
        }

        public class Client : EditorModel
        {
            public string email { get; set; }
            public string customer_name { get; set; }
        }

        public class Inventory1 : EditorModel
        {
            public int Size { get; set; }
        }
        
        public class Inventory2 : EditorModel
        {
            public int Size { get; set; }
        }
        
        public class Inventory3 : EditorModel
        {
            public int Size { get; set; }
        }
        
        public class Inventory4 : EditorModel
        {
            public int Size { get; set; }
        }
        
    }

    [RoutePrefix("api/table")]
    public class TableController : ApiController
    {
        [Route("updateshipping")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Shipped(ShippedModel myShippedOrder)
        {
            OrderRepository repo = new OrderRepository();
            bool ok = repo.UpdateOrderShipped(myShippedOrder);
            if(ok)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        
        [HttpGet]
        [HttpPost]
        [Route("getdata")]
        public IHttpActionResult Table()
        {
            var settings = Properties.Settings.Default;
            var request = HttpContext.Current.Request;
    
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                DtResponse response  = new Editor(db, "Order","Id")
                    .Model<JoinOrderClient>()
                    .Field(new Field("Order.InventoryItem1").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("Order.InventoryItem2").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("Order.InventoryItem3").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("Order.InventoryItem4").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("Order.ClientId")
                        .Options(new Options()
                            .Table("Client")
                            .Value("Id")
                            .Label("email","customer_name")
                        )
                        .Set( false )
                        .Validator(Validation.DbValues(new ValidationOpts { Empty = false }))
                    )
                    .LeftJoin("Client", "Client.Id", "=", "Order.ClientId")
                    .LeftJoin("Inventory as Inventory1", "Inventory1.Id", "=", "Order.InventoryItem1")
                    .LeftJoin("Inventory as Inventory2", "Inventory2.Id", "=", "Order.InventoryItem2")
                    .LeftJoin("Inventory as Inventory3", "Inventory3.Id", "=", "Order.InventoryItem3")
                    .LeftJoin("Inventory as Inventory4", "Inventory4.Id", "=", "Order.InventoryItem4")

                    .Process(request)
                    .Data();
                    
                return Json(response);
            }
        }
    }   
} 

