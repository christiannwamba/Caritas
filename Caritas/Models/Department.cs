using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class Department
    {
        public Department() {
            DateAdded = DateTime.Now;
        }
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Department cannot be longer than 50 characters.")]
        public string DepartmentName { get; set; }
        [Required]
        public string Description { get; set; }
        public int FacultyID { get; set; }
        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }
        public DateTime DateAdded { get; set; }
    }
}