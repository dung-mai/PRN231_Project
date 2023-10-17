using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Semester
    {
        public Semester()
        {
            Classes = new HashSet<Class>();
        }

        [Key]
        public int Id { get; set; }
        public short? Year { get; set; }
        [MaxLength(50)]
        public string? SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<Class> Classes { get; set; }
    }
}
