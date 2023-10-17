using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class StudyCourse
    {
        public StudyCourse()
        {
            SubjectResults = new HashSet<SubjectResult>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(9)]
        public string? Rollnumber { get; set; }
        public int? SubjectOfClassId { get; set; }
        public short? TryTime { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Student? RollnumberNavigation { get; set; }
        public virtual SubjectOfClass? SubjectOfClass { get; set; }
        public virtual ICollection<SubjectResult> SubjectResults { get; set; }
    }
}
