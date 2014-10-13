using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class Content
    {
        public Content() {
            DateAdded = DateTime.Now;
        }
        public int ContentID { get; set; }
        [Required]
        public string Content1 { get; set; }
        [Required]
        public string ContentType { get; set; }
        public DateTime DateAdded { get; set; }
        
    }
}