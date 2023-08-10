using System;
using System.Collections.Generic;

namespace CapstoneRegistration.Repository.Models
{
    public partial class TopicOfLecturer
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public int TopicId { get; set; }

        public virtual Lecturer Lecturer { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
