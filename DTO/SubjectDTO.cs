using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class SubjectDTO
    {
        public SubjectDTO()
        {
            GradeComponents = new HashSet<GradeComponentDTO>();
        }

        public int Id { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public DateTime? DateOfIssues { get; set; }
        public short? NumOfCredits { get; set; }
        public short? Status { get; set; }
        public short? TermNo { get; set; }

        public virtual ICollection<GradeComponentDTO> GradeComponents { get; set; }
    }
}
