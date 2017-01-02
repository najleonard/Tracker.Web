using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class TOAHController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            LLInventoryRepository3 repo = new LLInventoryRepository3();
            var model = repo.GetTOAHList();
            return View(model);
        }
    }
   // [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]

    public ActionResult Table()
    {
        var settings = Properties.Settings.Default;
        var formData = HttpContext.Request.Form;
 
        using (var db = new Database(settings.DbType, settings.DbConnection))
        {
            var response = new Editor(db, "ItemOrder")
                .Model<ItemOrder>()
                .Field(new Field("start_date")
                    .Validator(Validation.DateFormat(
                        Format.DATE_ISO_8601,
                        new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
                    ))
                    .GetFormatter(Format.DateSqlToFormat(Format.DATE_ISO_8601))
                    .SetFormatter(Format.DateFormatToSql(Format.DATE_ISO_8601))
                )
                .Process(formData)
                .Data();
 
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }

    
}