using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;
using System.Net.Mail;
using System.Net;

namespace Caritas.Helpers
{
    public class Lib : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void SendEmail(string address, string subject, string message)
        {
            string email = "nwambachristian@gmail.com";
            string password = "Obinna1712";

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            msg.From = new MailAddress(email);
            msg.To.Add(new MailAddress(address));
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;

            smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
        public void PageHit(Spy spy, string which) {
            
            spy.IPAddress = "127.0.0.1";
            spy.Page = which;
            db.Spy.Add(spy);
            db.SaveChanges();
        }
    }
}