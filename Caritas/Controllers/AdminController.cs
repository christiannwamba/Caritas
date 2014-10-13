using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;
using Caritas.ViewModel;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Caritas.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        #region Home
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Manage News
        public ActionResult ManageNews()
        {
            return View();
        }
        public JsonResult CreateNewsJson(News news)
        {
            string exp = "";
            try
            {
                if (ModelState.IsValid)
                {
                    db.News.Add(news);
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdminNewsForUpdate(int id)
        {
            var ns = (from n in db.News where n.NewsID == id select new { n.Title, n.NewsID, n.News1, n.Caption }).FirstOrDefault();
            return Json(ns, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateNews(News news)
        {
            string exp = "";
            string loggedIn = User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = (from n in db.News where n.NewsID == news.NewsID select n).FirstOrDefault();
                    ns.Title = news.Title;
                    ns.News1 = news.News1;
                    ns.Caption = news.Caption;
                    if (ns.UserID == loggedIn)
                    {
                        db.SaveChanges();
                    }
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteNews(int id)
        {
            string exp = "";
            string loggedIn = User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = db.News.Find(id);
                    db.News.Remove(ns);
                    if (ns.UserID == loggedIn)
                    {
                        db.SaveChanges();
                    }
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdminNewsBar()
        {
            var an = (from a in db.News orderby a.DateAdded descending select new { a.Title, a.User.FirstName, a.User.LastName, a.DateAdded, a.UserID, a.NewsID }).Take(10);
            return Json(an, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Manage Events
        public ActionResult ManageEvents()
        {
            return View();
        }
        public JsonResult CreateEventJson(Event events)
        {
            string exp = "";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Event.Add(events);
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdminEventForUpdate(int id)
        {
            var ns = (from n in db.Event where n.EventID == id select new { n.Title, n.EventID, n.Event1, n.Caption, n.EventDate }).FirstOrDefault();
            return Json(ns, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateEvent(Event events)
        {
            string exp = "";
            string loggedIn = User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = (from n in db.Event where n.EventID == events.EventID select n).FirstOrDefault();
                    ns.Title = events.Title;
                    ns.EventDate = events.EventDate;
                    ns.Event1 = events.Event1;
                    ns.Caption = events.Caption;
                    if (ns.UserID == loggedIn)
                    {
                        db.SaveChanges();
                    }
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEvent(int id)
        {
            string exp = "";
            string loggedIn = User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = db.Event.Find(id);
                    db.Event.Remove(ns);
                    if (ns.UserID == loggedIn)
                    {
                        db.SaveChanges();
                    }
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdminEventsBar()
        {
            var an = (from a in db.Event orderby a.DateAdded descending select new { a.Title, a.User.FirstName, a.User.LastName, a.DateAdded, a.UserID, a.EventID }).Take(10);
            return Json(an, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Courses
        //Index
        public ActionResult ManageCourses()
        {
            return View();
        }
        //Create Faculty
        public JsonResult CreateFaculty(Faculty faculty)
        {
            string exp = "";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Faculty.Add(faculty);
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        //Update Fac
        public JsonResult UpdateFaculty(Faculty faculty)
        {
            string exp = "";
            string loggedIn = User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = (from n in db.Faculty where n.FacultyID == faculty.FacultyID select n).FirstOrDefault();
                    ns.FacultyName = faculty.FacultyName;
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        //For Update(faculty)
        public JsonResult AdminFacultyForUpdate(int id)
        {
            var ns = (from n in db.Faculty where n.FacultyID == id select new { n.FacultyID, n.FacultyName }).FirstOrDefault();
            return Json(ns, JsonRequestBehavior.AllowGet);
        }
        //Create Dept
        public JsonResult CreateDept(Department dept)
        {
            string exp = "";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Department.Add(dept);
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AdminDeptForUpdate(int id)
        {
            var ns = (from n in db.Department where n.DepartmentID == id select new { n.DepartmentID, n.DepartmentName, n.Description, n.FacultyID }).FirstOrDefault();
            return Json(ns, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateDept(Department dept)
        {
            string exp = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = (from n in db.Department where n.DepartmentID == dept.DepartmentID select n).FirstOrDefault();
                    ns.DepartmentName = dept.DepartmentName;
                    ns.Description = dept.Description;
                    //ns.FacultyID = dept.FacultyID;
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdminFacultyBar()
        {
            var an = (from a in db.Faculty orderby a.FacultyName ascending select new { a.FacultyID, a.FacultyName, a.DateAdded }).Take(10);
            return Json(an, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AdminDeptBar()
        {
            var an = from a in db.Department orderby a.Faculty.FacultyName ascending select new { a.FacultyID, a.DepartmentName, a.DepartmentID, a.DateAdded, a.Faculty.FacultyName };
            return Json(an, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Contents
        public ActionResult ManageContents()
        {
            return View();
        }
        public JsonResult ContentForUpdate(string id)
        {
            var co = (from c in db.Content where c.ContentType == id select c).FirstOrDefault();
            return Json(co, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateContent(Content content)
        {
            string exp = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var ns = (from n in db.Content where n.ContentType == content.ContentType select n).FirstOrDefault();
                    ns.Content1 = content.Content1;
                    db.SaveChanges();
                    exp = "";
                }
            }
            catch (Exception ex)
            {
                exp = ex.Message.ToString();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        #region Projets
        public ActionResult ManageProjects()
        {
            var viewModel = new HomeViewModel();
            viewModel.Downloads = db.Downloads.OrderBy(x => x.Count).Take(10);
            ViewBag.TotalDowns = db.Downloads.Select(x => x.Count).Sum();
            return View(viewModel);
        }
        public JsonResult SelectFaculty()
        {
            var fac = from f in db.Faculty select new { f.FacultyID, f.FacultyName };
            return Json(fac, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SelectDepartment(int id)
        {
            var dept = from d in db.Department where d.FacultyID == id select new { d.DepartmentID, d.DepartmentName };
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult UploadProjects()
        {
            
            string newFileName = "";
            string path = "";
            HttpPostedFileBase file = Request.Files["photo"];
            Publication pub = new Publication();
            pub.Author = Request.Form["author"]; pub.AuthorRegNo = Request.Form["regNo"]; pub.Title = Request.Form["title"];
            pub.DepartmentID = 6;
            if (file != null && file.ContentLength > 0)
            {
                Guid fileId = Guid.NewGuid();
                var fileName = Path.GetFileName(file.FileName);
                newFileName = fileId + "_" + fileName;

                path = Path.Combine(Server.MapPath("~/App_Data/Uploads/Projects"), newFileName);
                file.SaveAs(path);
                pub.Dir = path;
                db.SaveChanges();
                return Json(pub.Dir, JsonRequestBehavior.AllowGet);
            }
            return Json(newFileName, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}