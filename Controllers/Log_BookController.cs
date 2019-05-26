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
    public class Log_BookController : Controller
    {
        private Diabetes_Helper_Entities db = new Diabetes_Helper_Entities();

        // GET: Log_Book
        public ActionResult Index()
        {
            var log_Book = db.Log_Book.Include(l => l.Meal_Routine).Include(l => l.User);
            return View(log_Book.ToList());
        }

        // GET: Log_Book/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log_Book log_Book = db.Log_Book.Find(id);
            if (log_Book == null)
            {
                return HttpNotFound();
            }
            return View(log_Book);
        }

        // GET: Log_Book/Create
        public ActionResult Create()
        {
            ViewBag.Routine_ID = new SelectList(db.Meal_Routine, "Routine_ID", "Routine_ID");
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name");
            return View();
        }

        // POST: Log_Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Log_Book_ID,User_ID,Log_Date,Log_Time,Meter_Reading,Log_Notes,Routine_ID")] Log_Book log_Book)
        {
            if (ModelState.IsValid)
            {
                db.Log_Book.Add(log_Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Routine_ID = new SelectList(db.Meal_Routine, "Routine_ID", "Routine_ID", log_Book.Routine_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name", log_Book.User_ID);
            return View(log_Book);
        }

        // GET: Log_Book/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log_Book log_Book = db.Log_Book.Find(id);
            if (log_Book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Routine_ID = new SelectList(db.Meal_Routine, "Routine_ID", "Routine_ID", log_Book.Routine_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name", log_Book.User_ID);
            return View(log_Book);
        }

        // POST: Log_Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Log_Book_ID,User_ID,Log_Date,Log_Time,Meter_Reading,Log_Notes,Routine_ID")] Log_Book log_Book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log_Book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Routine_ID = new SelectList(db.Meal_Routine, "Routine_ID", "Routine_ID", log_Book.Routine_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "First_Name", log_Book.User_ID);
            return View(log_Book);
        }

        // GET: Log_Book/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log_Book log_Book = db.Log_Book.Find(id);
            if (log_Book == null)
            {
                return HttpNotFound();
            }
            return View(log_Book);
        }

        // POST: Log_Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Log_Book log_Book = db.Log_Book.Find(id);
            db.Log_Book.Remove(log_Book);
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
