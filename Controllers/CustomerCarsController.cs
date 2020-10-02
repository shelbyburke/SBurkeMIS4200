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
    public class CustomerCarsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: CustomerCars
        public ActionResult Index()
        {
            return View(db.CustomerCars.ToList());
        }

        // GET: CustomerCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCar customerCar = db.CustomerCars.Find(id);
            if (customerCar == null)
            {
                return HttpNotFound();
            }
            return View(customerCar);
        }

        // GET: CustomerCars/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.CustomerCars, "customerCarId", "customerFullName");
            return View();
        }

        // POST: CustomerCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerCarId,customerCarFirstName,customerCarLastName,customerCarPhone,address")] CustomerCar customerCar)
        {
            if (ModelState.IsValid)
            {
                db.CustomerCars.Add(customerCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerCar);
        }

        // GET: CustomerCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCar customerCar = db.CustomerCars.Find(id);
            if (customerCar == null)
            {
                return HttpNotFound();
            }
            return View(customerCar);
        }

        // POST: CustomerCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerCarId,customerCarFirstName,customerCarLastName,customerCarPhone,address")] CustomerCar customerCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerCar);
        }

        // GET: CustomerCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCar customerCar = db.CustomerCars.Find(id);
            if (customerCar == null)
            {
                return HttpNotFound();
            }
            return View(customerCar);
        }

        // POST: CustomerCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerCar customerCar = db.CustomerCars.Find(id);
            db.CustomerCars.Remove(customerCar);
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
