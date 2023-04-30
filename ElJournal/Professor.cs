using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100, ErrorMessage = "Значение фамилии должно содержать не менее 3 символов.", MinimumLength = 3)]
        public string F { get; set; }
        [StringLength(100, ErrorMessage = "Значение имени должно содержать не менее 2 символов.", MinimumLength = 2)]
        public string I { get; set; }
        public string O { get; set; }

        public virtual ICollection<ProfessorsItem> ProfessorsItem { get; set; }
    }
}
