using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Academ
    {
        public Academ()
        {
            Commentary = new HashSet<Commentary>();
        }

        public int IdAcadem { get; set; }
        public string NumberAcadem { get; set; }
        public string FormControlAcadem { get; set; }
        public string FioprepodAcadem { get; set; }
        public DateTime DateAcadem { get; set; }
        public string TimeAcadem { get; set; }
        public string TerraAcadem { get; set; }

        public virtual ICollection<Commentary> Commentary { get; set; }
    }
}
