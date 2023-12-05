using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iwish.Models;

namespace iwish.Controllers
{

    [CustomAuthorize(Roles = "Inspector")]
    public class RentalsController : Controller
    {
        private ST10119360_CLDV6211_Part_2Entities db = new ST10119360_CLDV6211_Part_2Entities();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Car).Include(r => r.Driver).Include(r => r.Inspector);
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake");
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName");
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalNo,StartDate,EndDate,RentalFee,CarNo,InspectNO,DriverID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake", rental.CarNo);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", rental.DriverID);
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName", rental.InspectNO);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake", rental.CarNo);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", rental.DriverID);
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName", rental.InspectNO);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalNo,StartDate,EndDate,RentalFee,CarNo,InspectNO,DriverID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake", rental.CarNo);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", rental.DriverID);
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName", rental.InspectNO);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
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
