using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class InventoryRepository
    {
        public List<InventoryView> GetCurrentInventory()
        {
            List<InventoryView> retvalue = null;
            using(var db = new trackerwebdbEntities())
            {
                retvalue = db.InventoryViews.ToList();
            }
            return retvalue;
        }
    }

    public class LLInventoryRepository
    {
        public List<LLInventoryView> GetCurrentLLInventory(string sortOrder)
        {
            List<LLInventoryView> retvalue = null;
            using(var db = new trackerwebdbEntities())
            {
                var inventory = from s in db.LLInventoryViews
                  select s;
                inventory = inventory.OrderByDescending(s => s.Type);
                retvalue = inventory.ToList();
            }
            return retvalue;
        }
    }
}
