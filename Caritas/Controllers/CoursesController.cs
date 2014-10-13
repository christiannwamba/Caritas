using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;

namespace Caritas.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Faculties()
        {
            var fac = from f in db.Faculty select f;
            return Json(fac, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Departments(int id)
        {
            var fac = from f in db.Department where f.FacultyID == id select f;
            return Json(fac, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Description(int id)
        {
            var fac = (from f in db.Department where f.DepartmentID == id select f).FirstOrDefault();
            return Json(fac, JsonRequestBehavior.AllowGet);
        }
    }
}