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
using PagedList;

namespace RacingResource.Controllers
{
    public class JockeyController : Controller
    {
        private RacingResourceContext db = new RacingResourceContext();

        //
        // GET: /Jockey/

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
                return View(db.Jockeys.Where(j => j.Surname.ToLower().Contains(s.ToLower())).OrderBy(j => j.Surname).ToPagedList(page, 20));
            }


            return View(db.Jockeys.OrderBy(j => j.Surname).ToPagedList(page, 20));
        }

        //
        // GET: /Jockey/Details/5
        [OutputCache(Duration = 180)]
        public ActionResult Details(int id = 0, int? p = 1)
        {
            Jockey jockey = db.Jockeys.Find(id);
            if (jockey == null)
            {
                return HttpNotFound();
            }
            if (jockey.TwitterId != null)
            {
                var auth = TwitterUtilities.GetAuthorizer();
                var ctx = new TwitterContext(auth);
                var tweets =
                    from tweet in ctx.Status
                    where tweet.Type == StatusType.User
                          && tweet.ScreenName == jockey.TwitterId
                    select tweet;

                if (tweets != null)
                {
                    try
                    {
                        ViewData["Tweets"] = tweets.ToList();
                    }
                    catch
                    {
                        Console.WriteLine("Tweet problem...");
                    }
                }
            }
            int page = p ?? 1;
            ViewBag.Results = db.Results.Include("Race.Meeting.Course").Include("Horse").Where(r => r.Jockey.Id == jockey.Id).OrderByDescending(r => r.Race.OffTime).ToPagedList(page, 50);
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