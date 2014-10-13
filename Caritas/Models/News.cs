using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class News
    {
        public News() {
            DateAdded = DateTime.Now;
        }
        public int NewsID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string News1 { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Caption cannot be longer than 100 characters.")]
        public string Caption { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}