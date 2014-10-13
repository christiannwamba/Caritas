using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caritas.Models
{
    public class ContactUs
    {
        public int ContactUsID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]        
        public string Message { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Content cannot be longer than 50 characters.")]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}