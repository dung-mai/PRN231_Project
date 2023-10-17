using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Student
    {
        public Student()
        {
            StudyCourses = new HashSet<StudyCourse>();
        }
        [MaxLength(9)]
        [Key]
        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Account? Account { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<StudyCourse> StudyCourses { get; set; }
    }
}
