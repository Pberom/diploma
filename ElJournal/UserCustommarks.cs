using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class UserCustommarks
    {
        public UserCustommarks()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public int? NameItemId { get; set; }
        public int? EvaluationId { get; set; }

        public virtual Evaluation Evaluation { get; set; }
        public virtual NameItem NameItem { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
