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
    public class ReturnCarsController : Controller
    {
        private ST10119360_CLDV6211_Part_2Entities db = new ST10119360_CLDV6211_Part_2Entities();

        // GET: ReturnCars
        public ActionResult Index()
        {
            var returnCars = db.ReturnCars.Include(r => r.Car).Include(r => r.Driver).Include(r => r.Inspector);
            return View(returnCars.ToList());
        }

        // GET: ReturnCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnCar returnCar = db.ReturnCars.Find(id);
            if (returnCar == null)
            {
                return HttpNotFound();
            }
            return View(returnCar);
        }

        // GET: ReturnCars/Create
        public ActionResult Create()
        {
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake");
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName");
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName");
            return View();
        }

        // POST: ReturnCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReturnNo,ReturnDate,ElapsedDate,Fine,CarNo,InspectNO,DriverID")] ReturnCar returnCar)
        {
            if (ModelState.IsValid)
            {
                db.ReturnCars.Add(returnCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake", returnCar.CarNo);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", returnCar.DriverID);
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName", returnCar.InspectNO);
            return View(returnCar);
        }

        // GET: ReturnCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnCar returnCar = db.ReturnCars.Find(id);
            if (returnCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake", returnCar.CarNo);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", returnCar.DriverID);
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName", returnCar.InspectNO);
            return View(returnCar);
        }

        // POST: ReturnCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReturnNo,ReturnDate,ElapsedDate,Fine,CarNo,InspectNO,DriverID")] ReturnCar returnCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarMake", returnCar.CarNo);
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverID", "DriverName", returnCar.DriverID);
            ViewBag.InspectNO = new SelectList(db.Inspectors, "InspectNO", "InspectName", returnCar.InspectNO);
            return View(returnCar);
        }

        // GET: ReturnCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnCar returnCar = db.ReturnCars.Find(id);
            if (returnCar == null)
            {
                return HttpNotFound();
            }
            return View(returnCar);
        }

        // POST: ReturnCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnCar returnCar = db.ReturnCars.Find(id);
            db.ReturnCars.Remove(returnCar);
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
