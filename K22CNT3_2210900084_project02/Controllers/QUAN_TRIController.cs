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
    public class QUAN_TRIController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV_QUAN_TRI
        public ActionResult BAVIndex()
        {
            return View(db.QUAN_TRI.ToList());
        }

        // GET: BAV_QUAN_TRI/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // GET: BAV_QUAN_TRI/Create
        public ActionResult BAVCreate()
        {
            return View();
        }

        // POST: BAV_QUAN_TRI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_QL,Ten_QL,Email,Mat_khau")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI.Add(qUAN_TRI);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            return View(qUAN_TRI);
        }

        // GET: BAV_QUAN_TRI/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: BAV_QUAN_TRI/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_QL,Ten_QL,Email,Mat_khau")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            return View(qUAN_TRI);
        }

        // GET: BAV_QUAN_TRI/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: BAV_QUAN_TRI/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            db.QUAN_TRI.Remove(qUAN_TRI);
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
