using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Semestr
    {
        public Semestr()
        {
            Evaluation = new HashSet<Evaluation>();
        }

        public int IdSemestr { get; set; }
        public string NameSemesrt { get; set; }

        public virtual ICollection<Evaluation> Evaluation { get; set; }
    }
}
