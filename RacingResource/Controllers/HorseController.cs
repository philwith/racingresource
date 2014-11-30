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
    public class HorseController : Controller
    {
        private RacingResourceContext db = new RacingResourceContext();

        //
        // GET: /Horse/

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
                return View(db.Horses.Where(h => h.Name.ToLower().Contains(s.ToLower())).OrderBy(h => h.Name).ToPagedList(page, 20));
            }


            return View(db.Horses.OrderBy(h => h.Name).ToPagedList(page, 20));
        }

        //
        // GET: /Horse/Details/5

        public ActionResult Details(int id = 0)
        {
            Horse horse = db.Horses.Include("SireProgeny").Include("DamProgeny").FirstOrDefault<Horse>(h => h.Id == id);
            if (horse == null)
            {
                return HttpNotFound();
            }

            DateTime now = DateTime.Now;
            ViewBag.Results = (from r in db.Results.Include("Jockey").Include("Race.Meeting.Course")
                               where r.Horse.Id == id && r.Race.OffTime < now && !string.IsNullOrEmpty(r.Race.Name) && !string.IsNullOrEmpty(r.Position)
                               select r).ToList();

            return View(horse);
        }

        //
        // GET: /Horse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Horse/Create

        [HttpPost]
        public ActionResult Create(Horse horse)
        {
            if (ModelState.IsValid)
            {
                db.Horses.Add(horse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horse);
        }

        //
        // GET: /Horse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Horse horse = db.Horses.Find(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        //
        // POST: /Horse/Edit/5

        [HttpPost]
        public ActionResult Edit(Horse horse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horse);
        }

        //
        // GET: /Horse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Horse horse = db.Horses.Find(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        //
        // POST: /Horse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Horse horse = db.Horses.Find(id);
            db.Horses.Remove(horse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Sires(string term)
        {
            var data = (from Horse h in db.Horses
                        where h.Sex == "Colt" && h.Name.ToLower().StartsWith(term.ToLower())
                        select new { label = h.Name, value = h.Id }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Dams(string term)
        {
            var data = (from Horse h in db.Horses
                        where h.Sex == "Filly" && h.Name.ToLower().StartsWith(term.ToLower())
                        select new { label = h.Name, value = h.Id }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}