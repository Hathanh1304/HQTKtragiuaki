using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baiktragiuaki.Models;

namespace baiktragiuaki.Controllers
{
    public class hqtSinhViensController : Controller
    {
        private QLDEntities db = new QLDEntities();

        // GET: hqtSinhViens
        public ActionResult hqtIndex()
        {
            var sinhVien = db.SinhVien.Include(s => s.Khoa);
            return View(sinhVien.ToList());
        }

        // GET: hqtSinhViens/Details/5
        public ActionResult hqtDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: hqtSinhViens/Create
        public ActionResult hqtCreate()
        {
            ViewBag.MAKHOA = new SelectList(db.Khoa, "hqtMAKHOA", "hqtTENKHOA");
            return View();
        }

        // POST: hqtSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult hqtCreate([Bind(Include = "hqtMASV,hqtHOSV,hqtTENSV,hqtPHAI,hqtNS,hqtMAKHOA")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhVien.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKHOA = new SelectList(db.Khoa, "htqMAKHOA", "hqtTENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // GET: hqtSinhViens/Edit/5
        public ActionResult hqtEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKHOA = new SelectList(db.Khoa, "hqtMAKHOA", "hqtTENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // POST: hqtSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult hqtEdit([Bind(Include = "htqMASV,hqtHOSV,hqtTENSV,hqtPHAI,hqtNS,hqtMAKHOA")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKHOA = new SelectList(db.Khoa, "hqtMAKHOA", "hqtTENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }
        // GET: hqtSinhViens/Delete/5
        public ActionResult hqtDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: hqtSinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult hqtDeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhVien.Find(id);
            db.SinhVien.Remove(sinhVien);
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
