using System;
using System.Collections.Generic;

namespace CapstoneRegistration.Repository.Models
{
    public partial class Group
    {
        public Group()
        {
            LecturerInGroups = new HashSet<LecturerInGroup>();
            StudentInGroups = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfMember { get; set; }
        public int TopicId { get; set; }
        public int SemesterId { get; set; }
        public int Leader { get; set; }

        public virtual Student LeaderNavigation { get; set; } = null!;
        public virtual Semester Semester { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
        public virtual ICollection<LecturerInGroup> LecturerInGroups { get; set; }
        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
    }
}
