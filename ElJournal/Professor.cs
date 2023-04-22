using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Professor
    {
        public Professor()
        {
            ProfessorsItem = new HashSet<ProfessorsItem>();
        }

        public int Id { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }

        public virtual ICollection<ProfessorsItem> ProfessorsItem { get; set; }
    }
}
