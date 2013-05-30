using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RacingResource.Models;

namespace RacingResource.Controllers
{
    public class JockeyController : Controller
    {
        private RacingResourceContext db = new RacingResourceContext();

        //
        // GET: /Jockey/

        public ActionResult Index()
        {
            return View(db.Jockeys.ToList());
        }

        //
        // GET: /Jockey/Details/5

        public ActionResult Details(int id = 0)
        {
            Jockey jockey = db.Jockeys.Find(id);
            if (jockey == null)
            {
                return HttpNotFound();
            }
            return View(jockey);
        }

        //
        // GET: /Jockey/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Jockey/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jockey jockey)
        {
            if (ModelState.IsValid)
            {
                db.Jockeys.Add(jockey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jockey);
        }

        //
        // GET: /Jockey/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Jockey jockey = db.Jockeys.Find(id);
            if (jockey == null)
            {
                return HttpNotFound();
            }
            return View(jockey);
        }

        //
        // POST: /Jockey/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jockey jockey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jockey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jockey);
        }

        //
        // GET: /Jockey/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Jockey jockey = db.Jockeys.Find(id);
            if (jockey == null)
            {
                return HttpNotFound();
            }
            return View(jockey);
        }

        //
        // POST: /Jockey/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jockey jockey = db.Jockeys.Find(id);
            db.Jockeys.Remove(jockey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}