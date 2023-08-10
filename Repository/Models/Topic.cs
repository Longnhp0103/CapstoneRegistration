using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Groups = new HashSet<Group>();
            TopicOfLecturers = new HashSet<TopicOfLecturer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; } = null!;
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<TopicOfLecturer> TopicOfLecturers { get; set; }
    }
}
