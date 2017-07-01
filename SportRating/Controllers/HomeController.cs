using DAL;
using DB.Entities;
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
            UnitOfWork uow = new UnitOfWork();
            ViewBag.Title = "Home Page";
            uow.CountryRepository.Insert(new Country { Name = "Ukraine" });
            uow.Save();
            return View();
        }
    }
}
