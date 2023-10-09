using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public class Subject
    {
        public Subject()
        {
            GradeComponents = new HashSet<GradeComponent>();
            SubjectCurricolums = new HashSet<SubjectCurricolum>();
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }

        public int Id { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public DateTime? DateOfIssues { get; set; }
        public short? NumOfCredits { get; set; }
        public short? TermNo { get; set; }
        public short? Status { get; set; }

        public virtual ICollection<GradeComponent> GradeComponents { get; set; }
        public virtual ICollection<SubjectCurricolum> SubjectCurricolums { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
