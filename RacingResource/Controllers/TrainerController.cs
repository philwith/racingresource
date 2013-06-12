using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RacingResource.Models;
using PagedList;

namespace RacingResource.Controllers
{
    public class TrainerController : Controller
    {
        private RacingResourceContext db = new RacingResourceContext();

        //
        // GET: /Trainer/

        public ActionResult Index(int? p, string s, string cs)
        {
             int page = p ?? 1;
            ViewBag.Page = p;
            ViewBag.CurrentSearch = cs;

            if (Request.HttpMethod == "GET")
            {
                s = cs;
            }
            else
            {
                page = 1;
                ViewBag.Page = null;
            }
            ViewBag.CurrentSearch = s;
            if (!String.IsNullOrEmpty(s))
            {
                return View(db.Trainers.Where(t => (t.Forename + " " + t.Surname).ToLower().Contains(s.ToLower())).OrderBy(t => t.Surname).ToPagedList(page, 20));
            }
            return View(db.Trainers.OrderBy(t => t.Surname).ToPagedList(page, 20));
        }

        //
        // GET: /Trainer/Details/5

        public ActionResult Details(int id = 0)
        {
            Trainer trainer = db.Trainers.Include(t => t.Address).FirstOrDefault(t => t.Id == id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //
        // GET: /Trainer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trainer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        //
        // GET: /Trainer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View("Shared/",trainer);
        }

        //
        // POST: /Trainer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        //
        // GET: /Trainer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //
        // POST: /Trainer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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