using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMCStore.Models;

namespace LMCStore.Controllers
{
    [Authorize]
    public class AreasController : Controller
    {
        //private DbModel db = new DbModel();
        IMockAreas db;

        public AreasController()
        {
            this.db = new IDataAreas();
        }

        public AreasController(IMockAreas mockDb)
        {
            this.db = mockDb;
        }

        [AllowAnonymous]
        // GET: Areas
        public ActionResult Index()
        {
            return View("Index",db.Areas.OrderBy(c => c.Area_name).ToList());
        }

        // GET: Areas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Area area = db.Areas.Find(id);
            Area area = db.Areas.SingleOrDefault(c => c.Area_id == id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View("Details",area);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Area_id,Area_name,Area_level")] Area area)
        {
            if (ModelState.IsValid)
            {
                //db.Areas.Add(area);
                //db.SaveChanges();
                db.Save(area);
                return RedirectToAction("Index");
            }
            ViewBag.Area_id = new SelectList(db.Areas, "Area_id", "Area_name", area.Area_id);
            return View(area);
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Area area = db.Areas.Find(id);
            Area area = db.Areas.SingleOrDefault(c => c.Area_id == id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Area_id,Area_name,Area_level")] Area area)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(area).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(area);
                return RedirectToAction("Index");
            }
            return View("Edit",area);
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Area area = db.Areas.Find(id);
            Area area = db.Areas.SingleOrDefault(c => c.Area_id == id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Area area = db.Areas.Find(id);
            Area area = db.Areas.SingleOrDefault(c => c.Area_id == id);
            //db.Areas.Remove(area);
            //db.SaveChanges();
            db.Delete(area);
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
