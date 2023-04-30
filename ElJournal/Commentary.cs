using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Commentary
    {
        public int IdComm { get; set; }
        public string Commentary1 { get; set; }
        public int? AcademId { get; set; }
        public int? PracticeId { get; set; }
        public int? StudentsDannId { get; set; }

        public virtual Academ Academ { get; set; }
        public virtual Practice Practice { get; set; }
        public virtual Students StudentsDann { get; set; }
    }
}
