using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class Publication
    {
        public Publication()
        {
            DateUploaded = DateTime.Now;
        }
        public int PublicationID { get; set; }
        //[Required]
        public string Dir { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorRegNo { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}