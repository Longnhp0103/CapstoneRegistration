using System;
using System.Collections.Generic;

namespace CapstoneRegistration.Repository.Models
{
    public partial class StudentInGroup
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
