﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fortune_teller_mvc.Models;

namespace fortune_teller_mvc.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.BirthMonth).Include(c => c.FavoriteColor);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            Random randomNum = new Random();
            ViewBag.RetirementAge = (randomNum.Next(65, 97));
            ViewBag.VacationHome = "Goodyear, Arizona";
            ViewBag.Transportation = "red scooter";
            ViewBag.MoneyInBank = (randomNum.Next(10000, 1000001));
            return View(customer);  
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1");
            ViewBag.FavoriteColorID = new SelectList(db.FavoriteColors, "FavoriteColorID", "FavoriteColor1");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonthID,FavoriteColorID,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1", customer.BirthMonthID);
            ViewBag.FavoriteColorID = new SelectList(db.FavoriteColors, "FavoriteColorID", "FavoriteColor1", customer.FavoriteColorID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1", customer.BirthMonthID);
            ViewBag.FavoriteColorID = new SelectList(db.FavoriteColors, "FavoriteColorID", "FavoriteColor1", customer.FavoriteColorID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonthID,FavoriteColorID,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirthMonthID = new SelectList(db.BirthMonths, "BirthMonthID", "BirthMonth1", customer.BirthMonthID);
            ViewBag.FavoriteColorID = new SelectList(db.FavoriteColors, "FavoriteColorID", "FavoriteColor1", customer.FavoriteColorID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
