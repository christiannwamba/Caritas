using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;

namespace Caritas.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DateJoined = DateTime.Now;
        }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Publication> Publication { get; set; }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Downloads> Downloads { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<Spy> Spy { get; set; }
        

        //public System.Data.Entity.DbSet<Caritas.Models.ApplicationUser> IdentityUsers { get; set; }
    }
}