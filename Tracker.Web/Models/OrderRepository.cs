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
        public DateTime ShippedDate { get; set; }
    }
    
    public class OrderRepository
    {
        public int UpdateOrderShipped(ShippedModel myShippedOrder)
        {
            int affectedRows = 0;
            using (var db = new trackerwebdbEntities())
            {
                //update tagid, friendly name, description and (future) image blob
                var model = db.Orders.Where(x => x.Id == myShippedOrder.OrderId).First();
                model.Shipped = 1;
                model.ShippedDate = myShippedOrder.ShippedDate;
                affectedRows = db.SaveChanges();

                var model2 = db.Inventories.Where(x => x.Id == model.InventoryItem1).First();
                model2.Location = myShippedOrder.OrderId.ToString();
                //db.SaveChanges();
                
                var model3 = db.Inventories.Where(x => x.Id == model.InventoryItem2).First();
                model3.Location = myShippedOrder.OrderId.ToString();
                // db.SaveChanges();
                
                var model4 = db.Inventories.Where(x => x.Id == model.InventoryItem3).First();
                model4.Location = myShippedOrder.OrderId.ToString();
                // db.SaveChanges();
                
                var model5 = db.Inventories.Where(x => x.Id == model.InventoryItem4).First();
                model5.Location = myShippedOrder.OrderId.ToString();
                db.SaveChanges();
                
            }
            return affectedRows;
        }
    }
}
