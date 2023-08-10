using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Student
    {
        public Student()
        {
            Groups = new HashSet<Group>();
            StudentInGroups = new HashSet<StudentInGroup>();
            StudentInSemesters = new HashSet<StudentInSemester>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
    }
}
