using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Caritas.Models;

namespace Caritas.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Content> Welcome { get; set; }
        public IEnumerable<Content> EntryRequirements { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Downloads> Downloads { get; set; }
    }
}