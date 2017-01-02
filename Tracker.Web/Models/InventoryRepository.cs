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
        public List<LLInventoryView2> GetCurrentLLInventory(string sortOrder)
        {
            List<LLInventoryView2> retvalue = null;
            using(var db = new trackerwebdbEntities())
            {
                  retvalue = db.LLInventoryView2.ToList();
            }
            return retvalue;
        }
    }

    public class LLInventoryRepository3
    {
        public List<LLInventoryView3> GetTOAHList()
        {
            List<LLInventoryView3> retvalue = null;
            using(var db = new trackerwebdbEntities())
            {
                  retvalue = db.LLInventoryView3.ToList();
            }
            return retvalue;
        }
    }
}
