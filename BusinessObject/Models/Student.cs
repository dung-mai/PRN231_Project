using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public class Student
    {
        public Student()
        {
            StudyCourses = new HashSet<StudyCourse>();
        }

        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<StudyCourse> StudyCourses { get; set; }
    }
}
