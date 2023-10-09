using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public class SubjectResult
    {
        public SubjectResult()
        {
            DetailScores = new HashSet<DetailScore>();
        }

        public int Id { get; set; }
        public int? StudyCourseId { get; set; }
        public double? AverageMark { get; set; }
        public short? Status { get; set; }
        public string? Note { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual StudyCourse? StudyCourse { get; set; }
        public virtual ICollection<DetailScore> DetailScores { get; set; }
    }
}
