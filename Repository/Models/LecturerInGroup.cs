using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class LecturerInGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LecturerId { get; set; }
        public int InMainLecturer { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Lecturer InMainLecturerNavigation { get; set; } = null!;
        public virtual Lecturer Lecturer { get; set; } = null!;
    }
}
