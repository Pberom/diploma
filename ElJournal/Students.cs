using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Students
    {
        public Students()
        {
            Evaluation = new HashSet<Evaluation>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual UserStudent User { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
    }
}
