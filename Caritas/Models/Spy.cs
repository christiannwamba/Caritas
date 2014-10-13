using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class Spy
    {
        public Spy() {
            DateSpied = DateTime.Now;
        }
        public int SpyID { get; set; }
        public string IPAddress { get; set; }
        public string Page { get; set; }
        public DateTime DateSpied { get; set; }
    }
}