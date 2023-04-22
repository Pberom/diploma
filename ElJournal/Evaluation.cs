using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class Evaluation
    {
        public int Id { get; set; }
        public string Evaluation1 { get; set; }
        public int StudentId { get; set; }
        public int CodeProfessorItemId { get; set; }
        public int SemestrId { get; set; }

        public virtual ProfessorsItem CodeProfessorItem { get; set; }
        public virtual Semestr Semestr { get; set; }
        public virtual Students Student { get; set; }
    }
}
