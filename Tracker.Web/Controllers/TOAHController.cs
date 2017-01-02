using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;
using DataTables;
using System.Data.Common;
using System.Net.Http.Formatting;
using System.Web.Http;

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
        [HttpGet, HttpPost, Route("api/upload-many")]
        public IHttpActionResult Index()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                var response = new Editor(db, "users")
                    .Model<UploadManyModel>()
                    .Field(new Field("users.site")
                        .Options(new Options()
                            .Table("sites")
                            .Value("id")
                            .Label("name")
                        )
                    )
                    .LeftJoin("sites", "sites.id", "=", "users.site")
                    .MJoin(new MJoin("files")
                        .Link("users.id", "users_files.user_id")
                        .Link("files.id", "users_files.file_id")
                        .Field(
                            new Field("id")
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
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}