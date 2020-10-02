using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBurkeMIS4200.DAL;
using SBurkeMIS4200.Models;

namespace SBurkeMIS4200.Controllers
{
    public class SalespersonsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Salespersons
        public ActionResult Index()
        {
            return View(db.Salespeople.ToList());
        }

        // GET: Salespersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespeople.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // GET: Salespersons/Create
        public ActionResult Create()
        {

            ViewBag.ID = new SelectList(db.Salespeople, "salespersonId", "fullName");
            return View();
        }

        // POST: Salespersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "salespersonId,salespersonFirstName,salespersonLastName,email,salespersonPhone,salespersonAddress")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Salespeople.Add(salesperson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesperson);
        }

        // GET: Salespersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespeople.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // POST: Salespersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "salespersonId,salespersonFirstName,salespersonLastName,email,salespersonPhone,salespersonAddress")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesperson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesperson);
        }

        // GET: Salespersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespeople.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // POST: Salespersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salesperson salesperson = db.Salespeople.Find(id);
            db.Salespeople.Remove(salesperson);
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
