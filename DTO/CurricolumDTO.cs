using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class CurricolumDTO
    {
        public CurricolumDTO()
        {
            SubjectCurricolums = new HashSet<SubjectCurricolumDTO>();
        }

        public int Id { get; set; }
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }

        public virtual MajorDTO? Major { get; set; }
        public virtual ICollection<SubjectCurricolumDTO> SubjectCurricolums { get; set; }
    }
}
