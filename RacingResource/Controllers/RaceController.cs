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
    public class RaceController : Controller
    {
        private RacingResourceContext db = new RacingResourceContext();

        //
        // GET: /Race/

        public ActionResult Index()
        {
            return View(db.Races.ToList());
        }

        //
        // GET: /Race/Details/5

        public ActionResult Details(int id = 0)
        {
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        //
        // GET: /Race/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Race/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Race race)
        {
            if (ModelState.IsValid)
            {
                db.Races.Add(race);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(race);
        }

        //
        // GET: /Race/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        //
        // POST: /Race/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(race);
        }

        //
        // GET: /Race/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        //
        // POST: /Race/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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