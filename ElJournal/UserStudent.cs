using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class UserStudent
    {
        public UserStudent()
        {
            Students = new HashSet<Students>();
        }

        public int IdUserStudents { get; set; }
        public string NameS { get; set; }
        public string SecondS { get; set; }
        public string MiddleS { get; set; }
        public string Email { get; set; }
        public string OtherEmail { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
