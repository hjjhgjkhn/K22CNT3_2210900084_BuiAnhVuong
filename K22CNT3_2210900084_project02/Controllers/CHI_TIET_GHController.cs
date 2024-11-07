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
    public class CHI_TIET_GHController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV/CHI_TIET_GH
        public ActionResult BAVIndex()
        {
            var cHI_TIET_GH = db.CHI_TIET_GH.Include(c => c.GIO_HANG).Include(c => c.SAN_PHAM);
            return View(cHI_TIET_GH.ToList());
        }

        // GET: BAV/CHI_TIET_GH/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_GH cHI_TIET_GH = db.CHI_TIET_GH.Find(id);
            if (cHI_TIET_GH == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_GH);
        }

        // GET: BAV/CHI_TIET_GH/Create
        public ActionResult BAVCreate()
        {
            ViewBag.Ma_GH = new SelectList(db.GIO_HANG, "Ma_GH", "Ma_GH");
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP");
            return View();
        }

        // POST: BAV/CHI_TIET_GH/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_GH,Ma_SP,So_luong")] CHI_TIET_GH cHI_TIET_GH)
        {
            if (ModelState.IsValid)
            {
                db.CHI_TIET_GH.Add(cHI_TIET_GH);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            ViewBag.Ma_GH = new SelectList(db.GIO_HANG, "Ma_GH", "Ma_GH", cHI_TIET_GH.Ma_GH);
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP", cHI_TIET_GH.Ma_SP);
            return View(cHI_TIET_GH);
        }

        // GET: BAV/CHI_TIET_GH/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_GH cHI_TIET_GH = db.CHI_TIET_GH.Find(id);
            if (cHI_TIET_GH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_GH = new SelectList(db.GIO_HANG, "Ma_GH", "Ma_GH", cHI_TIET_GH.Ma_GH);
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP", cHI_TIET_GH.Ma_SP);
            return View(cHI_TIET_GH);
        }

        // POST: BAV/CHI_TIET_GH/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_GH,Ma_SP,So_luong")] CHI_TIET_GH cHI_TIET_GH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHI_TIET_GH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            ViewBag.Ma_GH = new SelectList(db.GIO_HANG, "Ma_GH", "Ma_GH", cHI_TIET_GH.Ma_GH);
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP", cHI_TIET_GH.Ma_SP);
            return View(cHI_TIET_GH);
        }

        // GET: BAV/CHI_TIET_GH/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_GH cHI_TIET_GH = db.CHI_TIET_GH.Find(id);
            if (cHI_TIET_GH == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_GH);
        }

        // POST: BAV/CHI_TIET_GH/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            CHI_TIET_GH cHI_TIET_GH = db.CHI_TIET_GH.Find(id);
            db.CHI_TIET_GH.Remove(cHI_TIET_GH);
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
