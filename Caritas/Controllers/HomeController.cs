using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;
using Caritas.ViewModel;
using Caritas.Helpers;

namespace Caritas.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Lib lib = new Lib();
        public ActionResult Index()
        {
            string curUrl = Request.Url.ToString();
            //lib.PageHit(new Spy(), curUrl);
            var viewmodel = new HomeViewModel();
            viewmodel.Welcome = from c in db.Content where c.ContentType == "Welcome" select c;
            viewmodel.EntryRequirements = from c in db.Content where c.ContentType == "Entry Requirements" select c;
            viewmodel.Events = (from e in db.Event orderby e.DateAdded descending select e).Take(5);
            viewmodel.News = (from e in db.News orderby e.DateAdded descending select e).Take(7);
            return View(viewmodel);
        }
        public JsonResult News()
        {
            var ns = (from e in db.News orderby e.DateAdded descending select new { e.DateAdded, e.Caption, e.NewsID, e.Title }).Take(7);
            return Json(ns, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Events()
        {
            var ns = (from e in db.Event orderby e.EventDate descending select new { e.DateAdded, e.Caption, e.EventID, e.Title, e.EventDate }).Take(7);
            return Json(ns, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}