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
    public class Insulin_DosageController : Controller
    {
        private Diabetes_Helper_Entities db = new Diabetes_Helper_Entities();

        // GET: Insulin_Dosage
        public ActionResult Index()
        {
            var insulin_Dosage = db.Insulin_Dosage.Include(i => i.Blood_Sugar_Range).Include(i => i.User);
            return View(insulin_Dosage.ToList());
        }

        // GET: Insulin_Dosage/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insulin_Dosage insulin_Dosage = db.Insulin_Dosage.Find(id);
            if (insulin_Dosage == null)
            {
                return HttpNotFound();
            }
            return View(insulin_Dosage);
        }

        // GET: Insulin_Dosage/Create
        public ActionResult Create()
        {
            ViewBag.Blood_Sugar_Range_ID = new SelectList(db.Blood_Sugar_Range, "Blood_Sugar_Range_ID", "Blood_Sugar_Range_ID");
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name");
            return View();
        }

        // POST: Insulin_Dosage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dosage_ID,User_ID,Blood_Sugar_Range_ID,Insulin_Dosage1")] Insulin_Dosage insulin_Dosage)
        {
            if (ModelState.IsValid)
            {
                db.Insulin_Dosage.Add(insulin_Dosage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Blood_Sugar_Range_ID = new SelectList(db.Blood_Sugar_Range, "Blood_Sugar_Range_ID", "Blood_Sugar_Range_ID", insulin_Dosage.Blood_Sugar_Range_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name", insulin_Dosage.User_ID);
            return View(insulin_Dosage);
        }

        // GET: Insulin_Dosage/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insulin_Dosage insulin_Dosage = db.Insulin_Dosage.Find(id);
            if (insulin_Dosage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Blood_Sugar_Range_ID = new SelectList(db.Blood_Sugar_Range, "Blood_Sugar_Range_ID", "Blood_Sugar_Range_ID", insulin_Dosage.Blood_Sugar_Range_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name", insulin_Dosage.User_ID);
            return View(insulin_Dosage);
        }

        // POST: Insulin_Dosage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dosage_ID,User_ID,Blood_Sugar_Range_ID,Insulin_Dosage1")] Insulin_Dosage insulin_Dosage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insulin_Dosage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Blood_Sugar_Range_ID = new SelectList(db.Blood_Sugar_Range, "Blood_Sugar_Range_ID", "Blood_Sugar_Range_ID", insulin_Dosage.Blood_Sugar_Range_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name", insulin_Dosage.User_ID);
            return View(insulin_Dosage);
        }

        // GET: Insulin_Dosage/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insulin_Dosage insulin_Dosage = db.Insulin_Dosage.Find(id);
            if (insulin_Dosage == null)
            {
                return HttpNotFound();
            }
            return View(insulin_Dosage);
        }

        // POST: Insulin_Dosage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Insulin_Dosage insulin_Dosage = db.Insulin_Dosage.Find(id);
            db.Insulin_Dosage.Remove(insulin_Dosage);
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
