using System.ComponentModel.DataAnnotations;

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
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string? SubjectCode { get; set; }
        [MaxLength(100)]
        public string? SubjectName { get; set; }
        public DateTime? DateOfIssues { get; set; }
        public short? NumOfCredits { get; set; }
        public short? TermNo { get; set; }
        public short? Status { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<GradeComponent> GradeComponents { get; set; }
        public virtual ICollection<SubjectCurricolum> SubjectCurricolums { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
