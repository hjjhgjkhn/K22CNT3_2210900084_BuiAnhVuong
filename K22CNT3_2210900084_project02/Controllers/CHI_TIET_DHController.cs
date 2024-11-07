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
    public class CHI_TIET_DHController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV/CHI_TIET_DH
        public ActionResult BAVIndex()
        {
            var cHI_TIET_DH = db.CHI_TIET_DH.Include(c => c.DON_HANG).Include(c => c.SAN_PHAM);
            return View(cHI_TIET_DH.ToList());
        }

        // GET: BAV/CHI_TIET_DH/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DH cHI_TIET_DH = db.CHI_TIET_DH.Find(id);
            if (cHI_TIET_DH == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_DH);
        }

        // GET: BAV/CHI_TIET_DH/Create
        public ActionResult BAVCreate()
        {
            ViewBag.Ma_DH = new SelectList(db.DON_HANG, "Ma_DH", "Trang_thai");
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP");
            return View();
        }

        // POST: BAV/CHI_TIET_DH/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_DH,Ma_SP,So_luong,Don_gia")] CHI_TIET_DH cHI_TIET_DH)
        {
            if (ModelState.IsValid)
            {
                db.CHI_TIET_DH.Add(cHI_TIET_DH);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            ViewBag.Ma_DH = new SelectList(db.DON_HANG, "Ma_DH", "Trang_thai", cHI_TIET_DH.Ma_DH);
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP", cHI_TIET_DH.Ma_SP);
            return View(cHI_TIET_DH);
        }

        // GET: BAV/CHI_TIET_DH/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DH cHI_TIET_DH = db.CHI_TIET_DH.Find(id);
            if (cHI_TIET_DH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_DH = new SelectList(db.DON_HANG, "Ma_DH", "Trang_thai", cHI_TIET_DH.Ma_DH);
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP", cHI_TIET_DH.Ma_SP);
            return View(cHI_TIET_DH);
        }

        // POST: BAV/CHI_TIET_DH/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_DH,Ma_SP,So_luong,Don_gia")] CHI_TIET_DH cHI_TIET_DH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHI_TIET_DH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            ViewBag.Ma_DH = new SelectList(db.DON_HANG, "Ma_DH", "Trang_thai", cHI_TIET_DH.Ma_DH);
            ViewBag.Ma_SP = new SelectList(db.SAN_PHAM, "Ma_SP", "Ten_SP", cHI_TIET_DH.Ma_SP);
            return View(cHI_TIET_DH);
        }

        // GET: BAV/CHI_TIET_DH/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHI_TIET_DH cHI_TIET_DH = db.CHI_TIET_DH.Find(id);
            if (cHI_TIET_DH == null)
            {
                return HttpNotFound();
            }
            return View(cHI_TIET_DH);
        }

        // POST: BAV/CHI_TIET_DH/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            CHI_TIET_DH cHI_TIET_DH = db.CHI_TIET_DH.Find(id);
            db.CHI_TIET_DH.Remove(cHI_TIET_DH);
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
