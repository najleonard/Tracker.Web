using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;


namespace Tracker.Web.Controllers
{
    internal class JoinOrderClient : EditorModel
    {
        public class Order : EditorModel
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

        public class Client : EditorModel
        {
            public string email { get; set; }
        }
    }

    
    public class TableController : ApiController
    {
        
        [Route("api/table")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult Table()
        {
            var settings = Properties.Settings.Default;
            var request = HttpContext.Current.Request;
    
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                DtResponse response  = new Editor(db, "Order","Id")
                    .Model<JoinOrderClient>()
                    .Field(new Field("InventoryItem1").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("InventoryItem2").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("InventoryItem3").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("InventoryItem4").SetFormatter( Format.IfEmpty( null ) ))
                    .Field(new Field("Order.ClientId")
                        .Options(new Options()
                            .Table("Client")
                            .Value("Id")
                            .Label("email")
                        )
                        .Set( false )
                        .Validator(Validation.DbValues(new ValidationOpts { Empty = false }))
                    )
                    .LeftJoin("Client", "Client.Id", "=", "Order.ClientId")
                    .Process(request)
                    .Data();
    
                return Json(response);
            }
        }
    }   
} 

