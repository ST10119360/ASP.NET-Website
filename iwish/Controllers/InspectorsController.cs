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
    public class InspectorsController : Controller
    {
        private ST10119360_CLDV6211_Part_2Entities db = new ST10119360_CLDV6211_Part_2Entities();

        // GET: Inspectors
        public ActionResult Index()
        {
            return View(db.Inspectors.ToList());
        }

        // GET: Inspectors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspector inspector = db.Inspectors.Find(id);
            if (inspector == null)
            {
                return HttpNotFound();
            }
            return View(inspector);
        }

        // GET: Inspectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inspectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InspectNO,InspectName,InspectEmail,InspectMobile")] Inspector inspector)
        {
            if (ModelState.IsValid)
            {
                db.Inspectors.Add(inspector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inspector);
        }

        // GET: Inspectors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspector inspector = db.Inspectors.Find(id);
            if (inspector == null)
            {
                return HttpNotFound();
            }
            return View(inspector);
        }

        // POST: Inspectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InspectNO,InspectName,InspectEmail,InspectMobile")] Inspector inspector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inspector);
        }

        // GET: Inspectors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspector inspector = db.Inspectors.Find(id);
            if (inspector == null)
            {
                return HttpNotFound();
            }
            return View(inspector);
        }

        // POST: Inspectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Inspector inspector = db.Inspectors.Find(id);
            db.Inspectors.Remove(inspector);
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
