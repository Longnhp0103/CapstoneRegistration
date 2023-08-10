using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            LecturerInGroupInMainLecturerNavigations = new HashSet<LecturerInGroup>();
            LecturerInGroupLecturers = new HashSet<LecturerInGroup>();
            TopicOfLecturers = new HashSet<TopicOfLecturer>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<LecturerInGroup> LecturerInGroupInMainLecturerNavigations { get; set; }
        public virtual ICollection<LecturerInGroup> LecturerInGroupLecturers { get; set; }
        public virtual ICollection<TopicOfLecturer> TopicOfLecturers { get; set; }
    }
}
