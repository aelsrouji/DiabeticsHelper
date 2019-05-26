using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiabeticsHelper;


namespace DiabeticsHelper.Controllers
{
    [Authorize]
    public class Blood_Sugar_RangeController : Controller
    {
        private Diabetes_Helper_Entities db = new Diabetes_Helper_Entities();

        // GET: Blood_Sugar_Range
        public ActionResult Index()
        {
            return View(db.Blood_Sugar_Range.ToList());
        }

        // GET: Blood_Sugar_Range/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Sugar_Range blood_Sugar_Range = db.Blood_Sugar_Range.Find(id);
            if (blood_Sugar_Range == null)
            {
                return HttpNotFound();
            }
            return View(blood_Sugar_Range);
        }

        // GET: Blood_Sugar_Range/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blood_Sugar_Range/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Blood_Sugar_Range_ID,Blood_Sugar_Range_From,Blood_Sugar_Range_To")] Blood_Sugar_Range blood_Sugar_Range)
        {
            if (ModelState.IsValid)
            {
                db.Blood_Sugar_Range.Add(blood_Sugar_Range);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blood_Sugar_Range);
        }

        // GET: Blood_Sugar_Range/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Sugar_Range blood_Sugar_Range = db.Blood_Sugar_Range.Find(id);
            if (blood_Sugar_Range == null)
            {
                return HttpNotFound();
            }
            return View(blood_Sugar_Range);
        }

        // POST: Blood_Sugar_Range/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Blood_Sugar_Range_ID,Blood_Sugar_Range_From,Blood_Sugar_Range_To")] Blood_Sugar_Range blood_Sugar_Range)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood_Sugar_Range).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blood_Sugar_Range);
        }

        // GET: Blood_Sugar_Range/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Sugar_Range blood_Sugar_Range = db.Blood_Sugar_Range.Find(id);
            if (blood_Sugar_Range == null)
            {
                return HttpNotFound();
            }
            return View(blood_Sugar_Range);
        }

        // POST: Blood_Sugar_Range/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood_Sugar_Range blood_Sugar_Range = db.Blood_Sugar_Range.Find(id);
            db.Blood_Sugar_Range.Remove(blood_Sugar_Range);
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
