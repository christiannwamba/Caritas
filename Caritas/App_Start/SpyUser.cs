using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caritas.Models;
namespace Caritas.App_Start
{
    public class SpyUser:Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void AddSpy()
        {
            Spy spy = new Spy();
            spy.IPAddress = Request.ServerVariables["REMOTE_ADDR"];
            db.Spy.Add(spy);
            db.SaveChanges();            
        }
    }
}