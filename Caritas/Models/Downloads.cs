using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class Downloads
    {
        public int DownloadsID { get; set; }
        public string File { get; set; }
        public int Count { get; set; }
    }
}