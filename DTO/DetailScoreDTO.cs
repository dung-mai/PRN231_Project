using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class DetailScoreDTO
    {
        public int Id { get; set; }
        public int? GradeComponentId { get; set; }
        public int? SubjectResultId { get; set; }
        public double? Mark { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Comment { get; set; }
        public string? Rollnumber { get; set; }
        public string? Fullname { get; set; }

        public virtual GradeComponentDTO? GradeComponent { get; set; }
    }
}
