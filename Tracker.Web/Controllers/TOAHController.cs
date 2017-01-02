using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    // public class TOAHController : Controller
    // {
    //     // GET: Inventory
    //     public ActionResult Index()
    //     {
    //         LLInventoryRepository3 repo = new LLInventoryRepository3();
    //         var model = repo.GetTOAHList();
    //         return View(model);
    //     }
    // }
    public class TOAHController : ApiController
   {
        [HttpGet, HttpPost, Route("api/upload")]
        public String Index()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            return settings.DbConnection;
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                var response = new Editor(db, "users")
                    .Model<UploadModel>()
                    .Field(new Field("image")
                        .SetFormatter(Format.IfEmpty(null))
                        .Upload(new Upload(request.PhysicalApplicationPath + @"uploads\__ID____EXTN__")
                            .Db("files", "id", new Dictionary<string, object>
                            {
                                {"web_path", Upload.DbType.WebPath},
                                {"system_path", Upload.DbType.SystemPath},
                                {"filename", Upload.DbType.FileName},
                                {"filesize", Upload.DbType.FileSize}
                            })
                        )
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}
