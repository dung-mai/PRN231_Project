using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class SubjectCurricolumDTO
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? CurricolumId { get; set; }
        public bool? Status { get; set; }
        public short? TermNo { get; set; }

        public virtual CurricolumDTO? Curricolum { get; set; }
        public virtual SubjectDTO? Subject { get; set; }
    }
}
