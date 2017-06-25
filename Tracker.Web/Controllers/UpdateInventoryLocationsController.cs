using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class UpdateInventoryLocationsController : Controller
    {
        private trackerwebdbEntities2 db = new trackerwebdbEntities2();

        // GET: UpdateInventoryLocations
        public ActionResult Index()
        {
            return View(db.UpdateInventoryLocations.ToList());
        }

        // GET: UpdateInventoryLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateInventoryLocation updateInventoryLocation = db.UpdateInventoryLocations.Find(id);
            if (updateInventoryLocation == null)
            {
                return HttpNotFound();
            }
            return View(updateInventoryLocation);
        }

        // GET: UpdateInventoryLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateInventoryLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryId,SKU,Name,Type,Size,Color,Extras,Location,status,estDeliveryDate,trackingNumber,isReturnLabel")] UpdateInventoryLocation updateInventoryLocation)
        {
            if (ModelState.IsValid)
            {
                db.UpdateInventoryLocations.Add(updateInventoryLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updateInventoryLocation);
        }

        // GET: UpdateInventoryLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateInventoryLocation updateInventoryLocation = db.UpdateInventoryLocations.Find(id);
            if (updateInventoryLocation == null)
            {
                return HttpNotFound();
            }
            return View(updateInventoryLocation);
        }

        // POST: UpdateInventoryLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId,SKU,Name,Type,Size,Color,Extras,Location,status,estDeliveryDate,trackingNumber,isReturnLabel")] UpdateInventoryLocation updateInventoryLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updateInventoryLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateInventoryLocation);
        }

        // GET: UpdateInventoryLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateInventoryLocation updateInventoryLocation = db.UpdateInventoryLocations.Find(id);
            if (updateInventoryLocation == null)
            {
                return HttpNotFound();
            }
            return View(updateInventoryLocation);
        }

        // POST: UpdateInventoryLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UpdateInventoryLocation updateInventoryLocation = db.UpdateInventoryLocations.Find(id);
            db.UpdateInventoryLocations.Remove(updateInventoryLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
