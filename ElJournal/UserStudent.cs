using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100, ErrorMessage = "Значение имени должно содержать не менее 2 символов.", MinimumLength = 2)]
        public string NameS { get; set; }
        [StringLength(100, ErrorMessage = "Значение фамилии должно содержать не менее 3 символов.", MinimumLength = 3)]
        public string SecondS { get; set; }
        public string MiddleS { get; set; }
        [StringLength(100, ErrorMessage = "Значение почты должно содержать не менее 6 символов.", MinimumLength = 6)]
        [EmailAddress(ErrorMessage = "Некорректный формат почты. Почта должна содержать знак @ и минимум одну точку, а также написана на латинице.")]
        public string Email { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный формат почты. Почта должна содержать знак @ и минимум одну точку, а также написана на латинице.")]
        public string OtherEmail { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
