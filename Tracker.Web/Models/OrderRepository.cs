using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class ShippedModel
    {
        public int OrderId { get; set; }
        public string ShippedDate { get; set; }
    }
    
    public class OrderRepository
    {
        public bool UpdateOrderShipped(ShippedModel myShippedOrder)
        {
            //int affectedRows = 0;
            using (var db = new trackerwebdbEntities2())
            {
                System.Diagnostics.Debug.WriteLine(myShippedOrder.OrderId);
                //return true;
                //update tagid, friendly name, description and (future) image blob
               
                var model = db.Orders.Where(x => x.Id == myShippedOrder.OrderId).First();
               
                model.Shipped = 1;
                model.ShippedDate = Convert.ToDateTime(myShippedOrder.ShippedDate);
                db.SaveChanges();

                if(model.InventoryItem1 != "")
                {
                    var model2 = db.Inventories.Where(x => x.Id == model.InventoryItem1).First();
                    model2.Location = myShippedOrder.OrderId.ToString();
                    db.SaveChanges();
                }
                if(model.InventoryItem2 != "")
                {
                var model3 = db.Inventories.Where(x => x.Id == model.InventoryItem2).First();
                model3.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
                if(model.InventoryItem3 != "")
                {
                var model4 = db.Inventories.Where(x => x.Id == model.InventoryItem3).First();
                model4.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
                if(model.InventoryItem4 != "")
                {
                var model5 = db.Inventories.Where(x => x.Id == model.InventoryItem4).First();
                model5.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
                if(model.InventoryItem5 != "")
                {
                var model6 = db.Inventories.Where(x => x.Id == model.InventoryItem5).First();
                model6.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
                if(model.InventoryItem6 != "")
                {
                var model7 = db.Inventories.Where(x => x.Id == model.InventoryItem6).First();
                model7.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
                if(model.InventoryItem7 != "")
                {
                var model8 = db.Inventories.Where(x => x.Id == model.InventoryItem7).First();
                model8.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
                if(model.InventoryItem8 != "")
                {
                var model9 = db.Inventories.Where(x => x.Id == model.InventoryItem8).First();
                model9.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                }
            }
            return true;
        }
    }
}
