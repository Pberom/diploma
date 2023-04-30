using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100, ErrorMessage = "Значение должно содержать не менее 6 символов.", MinimumLength = 6)]
        public string CodeGroup { get; set; }
        [StringLength(100, ErrorMessage = "Значение должно содержать не менее 6 символов.", MinimumLength = 6)]
        public string NameGroup { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
