using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class NameItem
    {
        public NameItem()
        {
            ProfessorsItem = new HashSet<ProfessorsItem>();
        }

        public int Id { get; set; }
        public string NameItem1 { get; set; }

        public virtual ICollection<ProfessorsItem> ProfessorsItem { get; set; }
    }
}
