using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Practice
    {
        public Practice()
        {
            Commentary = new HashSet<Commentary>();
        }

        public int IdPractice { get; set; }
        public string NumberPractice { get; set; }
        public string NamePractice { get; set; }
        public string DatePlacePractice { get; set; }
        public string FioprepodPractic { get; set; }

        public virtual ICollection<Commentary> Commentary { get; set; }
    }
}
