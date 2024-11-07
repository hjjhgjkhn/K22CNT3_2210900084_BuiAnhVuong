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
    public class KHACH_HANGController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV/KHACH_HANG
        public ActionResult BAVIndex()
        {
            return View(db.KHACH_HANG.ToList());
        }

        // GET: BAV/KHACH_HANG/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // GET: BAV/KHACH_HANG/Create
        public ActionResult BAVCreate()
        {
            return View();
        }

        // POST: BAV/KHACH_HANG/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_KH,Ten_KH,Email,SDT,Dia_chi,Mat_khau")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            return View(kHACH_HANG);
        }

        // GET: BAV/KHACH_HANG/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: BAV/KHACH_HANG/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_KH,Ten_KH,Email,SDT,Dia_chi,Mat_khau")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            return View(kHACH_HANG);
        }

        // GET: BAV/KHACH_HANG/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: BAV/KHACH_HANG/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            db.KHACH_HANG.Remove(kHACH_HANG);
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
