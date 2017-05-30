using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Web.Models
{
    public class InventoryRepository
    {
        public List<FullInventoryView> GetCurrentInventory()
        {
            List<FullInventoryView> retvalue = null;
            using(var db = new trackerwebdbEntities2())
            {
                retvalue = db.FullInventoryViews.ToList();
            }
            return retvalue;
        }
    }

    public class LLInventoryRepository
    {
        public List<TryOnAtHomeView> GetCurrentLLInventory(string sortOrder)
        {
            List<TryOnAtHomeView> retvalue = null;
            using(var db = new trackerwebdbEntities2())
            {
                  retvalue = db.TryOnAtHomeViews.ToList();
            }
            return retvalue;
        }
    }
}
