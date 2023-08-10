using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Groups = new HashSet<Group>();
            StudentInSemesters = new HashSet<StudentInSemester>();
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
