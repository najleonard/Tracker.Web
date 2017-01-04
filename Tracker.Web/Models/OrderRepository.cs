using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class OrderRepository
    {
        public bool UpdateOrderShipped(int OrderId)
        {
            int affectedRows = 0;
            using (var db = new trackerwebdbEntities())
            {
                //update tagid, friendly name, description and (future) image blob
                var model = db.Orders.Where(x => x.Id == OrderId).First();
                model.Shipped = 1;
                affectedRows = db.SaveChanges();
            }
            return affectedRows > 0;
        }
    }
}
