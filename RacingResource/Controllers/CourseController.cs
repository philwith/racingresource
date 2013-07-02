using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RacingResource.Models;
using RacingResource.Utilities;
using LinqToTwitter;

namespace RacingResource.Controllers
{
    public class CourseController : Controller
    {
        private RacingResourceContext db = new RacingResourceContext();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        //
        // GET: /Course/Details/5

        [OutputCache(Duration = 180)]
        public ActionResult Details(int id = 0)
        {
            Course course = db.Courses.Include(t => t.Address).FirstOrDefault(t => t.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            if (course.TwitterId != null)
            {
                var auth = TwitterUtilities.GetAuthorizer();
                var ctx = new TwitterContext(auth);
                var tweets =
                    from tweet in ctx.Status
                    where tweet.Type == StatusType.User
                          && tweet.ScreenName == course.TwitterId
                    select tweet;

                if (tweets != null)
                {
                    ViewBag.Tweets = tweets.ToList();
                }
            }
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "PostalCode");
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "PostalCode");
            return View(course);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            if (course.AddressId != null)
            {
                ViewBag.Addresses = new SelectList(db.Addresses, "Id", "PostalCode");
            }
            else
            {
                ViewBag.Addresses = new SelectList(db.Addresses, "Id", "PostalCode", course.AddressId);
            }
            return View(course);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "PostalCode");
            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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