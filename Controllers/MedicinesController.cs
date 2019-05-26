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
    public class MedicinesController : Controller
    {
        private Diabetes_Helper_Entities db = new Diabetes_Helper_Entities();

        // GET: Medicines
        public ActionResult Index()
        {
            return View(db.Medicines.ToList());
        }

        // GET: Medicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: Medicines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medicine_ID,Medicine_Name")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medicine_ID,Medicine_Name")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            db.Medicines.Remove(medicine);
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
