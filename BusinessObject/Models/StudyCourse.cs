using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public class StudyCourse
    {
        public StudyCourse()
        {
            SubjectResults = new HashSet<SubjectResult>();
        }

        public int Id { get; set; }
        public string? Rollnumber { get; set; }
        public int? SubjectOfClassId { get; set; }
        public short? TryTime { get; set; }

        public virtual Student? RollnumberNavigation { get; set; }
        public virtual SubjectOfClass? SubjectOfClass { get; set; }
        public virtual ICollection<SubjectResult> SubjectResults { get; set; }
    }
}
