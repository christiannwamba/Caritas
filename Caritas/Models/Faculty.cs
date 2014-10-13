using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class Faculty
    {
        public Faculty() {
            DateAdded = DateTime.Now;
        }
        public int FacultyID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Faculty cannot be longer than 50 characters.")]
        public string FacultyName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}