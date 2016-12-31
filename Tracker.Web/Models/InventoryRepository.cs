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
                  retvalue = db.LLInventoryViews.ToList();
                /*var inventory = from s in db.LLInventoryViews
                  select s;
                inventory = inventory.OrderBy(s => s.Type);
                
                string searchString = "";
                if (!String.IsNullOrEmpty(searchString))
                {
                    inventory = inventory.Where(s => s.Type.Contains(searchString));
                }
                retvalue = inventory.ToList();*/
            }
            return retvalue;
        }
    }
}
