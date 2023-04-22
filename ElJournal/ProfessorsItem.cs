using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class ProfessorsItem
    {
        public ProfessorsItem()
        {
            Evaluation = new HashSet<Evaluation>();
        }

        public int Id { get; set; }
        public int? ProfessorId { get; set; }
        public int? ItemId { get; set; }

        public virtual NameItem Item { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
    }
}
