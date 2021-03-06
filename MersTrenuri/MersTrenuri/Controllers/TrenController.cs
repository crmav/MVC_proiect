﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MersTrenuri.DAL;
using MersTrenuri.Models;

namespace MersTrenuri.Controllers
{
    public class TrenController : Controller
    {
        private Context db = new Context();

        // GET: Tren
        public ActionResult Index()
        {
            return View(db.Trenuri.ToList());
        }

        // GET: Tren/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tren tren = db.Trenuri.Find(id);
            if (tren == null)
            {
                return HttpNotFound();
            }
            return View(tren);
        }

        // GET: Tren/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tren/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rang")] Tren tren)
        {
            if (ModelState.IsValid)
            {
                db.Trenuri.Add(tren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tren);
        }

        // GET: Tren/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tren tren = db.Trenuri.Find(id);
            if (tren == null)
            {
                return HttpNotFound();
            }
            return View(tren);
        }

        // POST: Tren/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rang")] Tren tren)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tren);
        }

        // GET: Tren/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tren tren = db.Trenuri.Find(id);
            if (tren == null)
            {
                return HttpNotFound();
            }
            return View(tren);
        }

        // POST: Tren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tren tren = db.Trenuri.Find(id);
            db.Trenuri.Remove(tren);
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
