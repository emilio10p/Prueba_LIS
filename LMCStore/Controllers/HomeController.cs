using LMCStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMCStore.Controllers
{
    public class HomeController : Controller
    {
        private DbModel db = new DbModel();
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult Autoparts ()
        {
            var autopart = db.Products.ToList();

            return View(autopart);
        }

        public ActionResult ViewAutopart (string AutopartName)
        {
            ViewBag.AutopartName = AutopartName;
            return View();
        }

        public ActionResult Areas ()
        {
            return View();
        }
    }
}