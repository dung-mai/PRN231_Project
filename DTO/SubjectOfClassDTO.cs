using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class SubjectOfClassDTO
    {
        public SubjectOfClassDTO()
        {
            StudyCourses = new HashSet<StudyCourseDTO>();
        }

        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ClassDTO? Class { get; set; }
        public virtual SubjectDTO? Subject { get; set; }
        public virtual AccountDTO? Teacher { get; set; }
        public virtual ICollection<StudyCourseDTO> StudyCourses { get; set; }
    }
}
