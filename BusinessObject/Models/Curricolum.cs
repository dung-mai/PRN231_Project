using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Curricolum
    {
        public Curricolum()
        {
            SubjectCurricolums = new HashSet<SubjectCurricolum>();
            Students = new HashSet<Student>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Major? Major { get; set; }
        public virtual ICollection<SubjectCurricolum> SubjectCurricolums { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
