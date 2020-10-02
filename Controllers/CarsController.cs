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
    public class CarsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.CustomerCar).Include(c => c.Salesperson);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.customerCarId = new SelectList(db.CustomerCars, "customerCarId", "customerFullName");
            ViewBag.salespersonId = new SelectList(db.Salespeople, "salespersonId", "salespersonFullName");


            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carId,make,model,year,color,salespersonId,customerCarId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerCarId = new SelectList(db.CustomerCars, "customerCarId", "customerCarFirstName", car.customerCarId);
            ViewBag.salespersonId = new SelectList(db.Salespeople, "salespersonId", "salespersonFirstName", car.salespersonId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerCarId = new SelectList(db.CustomerCars, "customerCarId", "customerFullName", car.customerCarId);
            ViewBag.salespersonId = new SelectList(db.Salespeople, "salespersonId", "salespersonFullName", car.salespersonId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carId,make,model,year,color,salespersonId,customerCarId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.customerCarId = new SelectList(db.CustomerCars, "customerCarId", "customerFullName");
            //ViewBag.salespersonId = new SelectList(db.Salespeople, "salespersonId", "salespersonFullName");
            
            ViewBag.customerCarId = new SelectList(db.CustomerCars, "customerCarId", "customerFullName", car.customerCarId);
            ViewBag.salespersonId = new SelectList(db.Salespeople, "salespersonId", "salespersonFullName", car.salespersonId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
