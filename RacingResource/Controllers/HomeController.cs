﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingResource.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [OutputCache(Duration=180)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
