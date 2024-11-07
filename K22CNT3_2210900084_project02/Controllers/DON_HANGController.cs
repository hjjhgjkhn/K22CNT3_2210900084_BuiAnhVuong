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
    public class DON_HANGController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV/DON_HANG
        public ActionResult BAVIndex()
        {
            var dON_HANG = db.DON_HANG.Include(d => d.KHACH_HANG);
            return View(dON_HANG.ToList());
        }

        // GET: BAV/DON_HANG/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        // GET: BAV/DON_HANG/Create
        public ActionResult BAVCreate()
        {
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH");
            return View();
        }

        // POST: BAV/DON_HANG/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_DH,Ma_KH,Ngay_dat,Tong_tien,Trang_thai")] DON_HANG dON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.DON_HANG.Add(dON_HANG);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH", dON_HANG.Ma_KH);
            return View(dON_HANG);
        }

        // GET: BAV/DON_HANG/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH", dON_HANG.Ma_KH);
            return View(dON_HANG);
        }

        // POST: BAV/DON_HANG/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_DH,Ma_KH,Ngay_dat,Tong_tien,Trang_thai")] DON_HANG dON_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dON_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ten_KH", dON_HANG.Ma_KH);
            return View(dON_HANG);
        }

        // GET: BAV/DON_HANG/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        // POST: BAV/DON_HANG/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            db.DON_HANG.Remove(dON_HANG);
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
