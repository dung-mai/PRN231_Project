using System;
using System.Collections.Generic;

namespace BusinessOject.Models
{
    public class Semester
    {
        public Semester()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public short? Year { get; set; }
        public string? SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
