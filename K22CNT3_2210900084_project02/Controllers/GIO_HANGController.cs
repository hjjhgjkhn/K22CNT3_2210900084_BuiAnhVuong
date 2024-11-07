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
    public class GIO_HANGController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV/GIO_HANG
        public ActionResult BAVIndex()
        {
            var gIO_HANG = db.GIO_HANG.Include(g => g.KHACH_HANG);
            return View(gIO_HANG.ToList());
        }

        // GET: BAV/GIO_HANG/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            if (gIO_HANG == null)
            {
                return HttpNotFound();
            }
            return View(gIO_HANG);
        }

        // GET: BAV/GIO_HANG/Create
        public ActionResult BAVCreate()
        {
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH");
            return View();
        }

        // POST: BAV/GIO_HANG/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_GH,Ma_KH,Ngay_tao")] GIO_HANG gIO_HANG)
        {
            if (ModelState.IsValid)
            {
                db.GIO_HANG.Add(gIO_HANG);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH", gIO_HANG.Ma_KH);
            return View(gIO_HANG);
        }

        // GET: BAV/GIO_HANG/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            if (gIO_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH", gIO_HANG.Ma_KH);
            return View(gIO_HANG);
        }

        // POST: BAV/GIO_HANG/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_GH,Ma_KH,Ngay_tao")] GIO_HANG gIO_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIO_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH", gIO_HANG.Ma_KH);
            return View(gIO_HANG);
        }

        // GET: BAV/GIO_HANG/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            if (gIO_HANG == null)
            {
                return HttpNotFound();
            }
            return View(gIO_HANG);
        }

        // POST: BAV/GIO_HANG/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            db.GIO_HANG.Remove(gIO_HANG);
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
