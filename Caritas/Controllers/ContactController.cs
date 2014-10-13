using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;
using System.Net.Mail;
using Caritas.Helpers;
namespace Caritas.Controllers
{

    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Lib lib = new Lib();

        public ActionResult Index()
        {

            var content = db.Content.Where(c => c.ContentType == "Contact Us").FirstOrDefault();
            return View(content);
        }
        [HttpPost]
        public ActionResult Index(ContactUs contact)
        {
            var subject = "Customer Support";
            var body = "Help support from "
                +contact.Name+ " \n"
                +contact.Message+ "\nPhone:"
                +contact.Phone;
            lib.SendEmail(contact.Email, subject, body);
            return Redirect("~/");
        }
    }
}