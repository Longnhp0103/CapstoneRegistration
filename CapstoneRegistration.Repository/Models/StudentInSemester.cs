using System;
using System.Collections.Generic;

namespace CapstoneRegistration.Repository.Models
{
    public partial class StudentInSemester
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
