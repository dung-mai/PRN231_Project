using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class StudyCourseDTO
    {
        public StudyCourseDTO()
        {
            SubjectResults = new HashSet<SubjectResultDTO>();
        }

        public int Id { get; set; }
        public string? Rollnumber { get; set; }
        public int? SubjectOfClassId { get; set; }
        public short? TryTime { get; set; }

        public virtual StudentDTO? RollnumberNavigation { get; set; }
        public virtual SubjectOfClassDTO? SubjectOfClass { get; set; }
        public virtual ICollection<SubjectResultDTO> SubjectResults { get; set; }
    }
}
