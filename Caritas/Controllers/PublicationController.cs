using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;

namespace Caritas.Controllers
{
    public class PublicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Publication/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Projects()
        {
            // Modify this path as necessary. 
            string startFolder = Server.MapPath(@"~/App_Data/Uploads/Projects");

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions 
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //string searchTerm = @"Visual Studio";
            var queryMatchingFiles =
                from file in fileList
                where file.Extension == ".pdf"
                let fileText = GetFileText(file.FullName)//GetFileText(string fileName) was decalred uder this method
                //where fileText.Contains(searchTerm)
                select file.Name;
            return Json(queryMatchingFiles, JsonRequestBehavior.AllowGet);

        }

        // Read the contents of the file. 
        static string GetFileText(string name)
        {
            string fileContents = String.Empty;

            // If the file has been deleted since we took  
            // the snapshot, ignore it and return the empty string. 
            if (System.IO.File.Exists(name))
            {
                fileContents = System.IO.File.ReadAllText(name);
            }
            return fileContents;
        }

        public FileResult DowloadProject(string id)
        {
            // Modify this path as necessary. 
            string startFolder = Server.MapPath(@"~/App_Data/Uploads/Projects");

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions 
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //string searchTerm = @"Visual Studio";
            var queryMatchingFiles =
                (from file in fileList
                 where file.Extension == ".pdf"
                 let fileText = file.Name//GetFileText(string fileName) was decalred uder this method
                 where fileText == id
                 select new { file.FullName, file.Name }).FirstOrDefault();
            var downloads = new Downloads();
            var checkFile = (from c in db.Downloads where c.File == queryMatchingFiles.Name select c.File).FirstOrDefault();
            if (checkFile.Count() < 1)
            {
                downloads.Count = 1;
                downloads.File = queryMatchingFiles.Name;
                db.Downloads.Add(downloads);
                db.SaveChanges();
            }
            else {
                var checkFile2 = (from c in db.Downloads where c.File == queryMatchingFiles.Name select c).FirstOrDefault();
                checkFile2.Count = checkFile2.Count + 1;
                db.SaveChanges();
            }
            return File(queryMatchingFiles.FullName, "application/pdf");
        }

    }
}