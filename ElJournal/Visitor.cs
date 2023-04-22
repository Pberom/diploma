using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Visitor
    {
        public Visitor()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int IdVisitor { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
