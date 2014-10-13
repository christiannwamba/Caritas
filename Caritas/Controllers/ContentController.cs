using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;
namespace Caritas.Controllers
{
    public class ContentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult About()
        {
            var content = db.Content.Where(c => c.ContentType == "About").FirstOrDefault();
            return View(content);
        }
        public ActionResult Admission()
        {
            var content = db.Content.Where(c => c.ContentType == "Admission").FirstOrDefault();
            return View(content);
        }
        public ActionResult News(int id) {
            var news = (from n in db.News where n.NewsID == id select n).FirstOrDefault();
            return View(news);
        }
        public ActionResult Event(int id)
        {
            var events = (from n in db.Event where n.EventID == id select n).FirstOrDefault();
            return View(events);
        }
        
	}
}