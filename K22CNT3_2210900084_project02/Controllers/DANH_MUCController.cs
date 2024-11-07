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
    public class DANH_MUCController : Controller
    {
        private BAVEntities db = new BAVEntities();

        // GET: BAV/DANH_MUC
        public ActionResult BAVIndex()
        {
            return View(db.DANH_MUC.ToList());
        }

        // GET: BAV/DANH_MUC/Details/5
        public ActionResult BAVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // GET: BAV/DANH_MUC/Create
        public ActionResult BAVCreate()
        {
            return View();
        }

        // POST: BAV/DANH_MUC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVCreate([Bind(Include = "Ma_DM,Ten_DM")] DANH_MUC dANH_MUC)
        {
            if (ModelState.IsValid)
            {
                db.DANH_MUC.Add(dANH_MUC);
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }

            return View(dANH_MUC);
        }

        // GET: BAV/DANH_MUC/Edit/5
        public ActionResult BAVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // POST: BAV/DANH_MUC/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAVEdit([Bind(Include = "Ma_DM,Ten_DM")] DANH_MUC dANH_MUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_MUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BAVIndex");
            }
            return View(dANH_MUC);
        }

        // GET: BAV/DANH_MUC/Delete/5
        public ActionResult BAVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            if (dANH_MUC == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC);
        }

        // POST: BAV/DANH_MUC/Delete/5
        [HttpPost, ActionName("BAVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BAVDeleteConfirmed(int id)
        {
            DANH_MUC dANH_MUC = db.DANH_MUC.Find(id);
            db.DANH_MUC.Remove(dANH_MUC);
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
