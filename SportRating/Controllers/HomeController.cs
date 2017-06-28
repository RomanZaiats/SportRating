﻿using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRating.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            SportRatingContext db = new SportRatingContext();
            db.Countries.Add(new DB.Entities.Country { Name = "Ukraine" });
            db.SaveChanges();
            return View();
        }
    }
}