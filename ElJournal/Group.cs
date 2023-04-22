using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string CodeGroup { get; set; }
        public string NameGroup { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
