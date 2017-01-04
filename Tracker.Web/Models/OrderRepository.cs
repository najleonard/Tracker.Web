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
                model.Shipped = myShippedOrder.OrderId;
                model.ShippedDate = myShippedOrder.ShippedDate;
                
                affectedRows = db.SaveChanges();
            }
            return affectedRows;
        }
    }
}
