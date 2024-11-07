using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_2210900084_project02.Models;

namespace K22CNT3_2210900084_project02.Controllers
{
    public class SAN_PHAMController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV_SAN_PHAM
        public ActionResult BAVIndex()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.DANH_MUC);
            return View(sAN_PHAM.ToList());
        }

        // GET: BAV_SAN_PHAM/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: BAV_SAN_PHAM/Create
        public ActionResult BAVCreate()
        {
            ViewBag.Ma_DM = new SelectList(db.DANH_MUC, "Ma_DM", "Ten_DM");
            return View();
        }

        // POST: BAV_SAN_PHAM/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_SP,Ten_SP,Gia,Mo_ta,So_luong,Ma_DM")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.SAN_PHAM.Add(sAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            ViewBag.Ma_DM = new SelectList(db.DANH_MUC, "Ma_DM", "Ten_DM", sAN_PHAM.Ma_DM);
            return View(sAN_PHAM);
        }

        // GET: BAV_SAN_PHAM/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_DM = new SelectList(db.DANH_MUC, "Ma_DM", "Ten_DM", sAN_PHAM.Ma_DM);
            return View(sAN_PHAM);
        }

        // POST: BAV_SAN_PHAM/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_SP,Ten_SP,Gia,Mo_ta,So_luong,Ma_DM")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            ViewBag.Ma_DM = new SelectList(db.DANH_MUC, "Ma_DM", "Ten_DM", sAN_PHAM.Ma_DM);
            return View(sAN_PHAM);
        }

        // GET: BAV_SAN_PHAM/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: BAV_SAN_PHAM/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
            db.SaveChanges();
            return RedirectToAction("BAVIndex");
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
