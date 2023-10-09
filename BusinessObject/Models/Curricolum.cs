using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Curricolum
    {
        public Curricolum()
        {
            SubjectCurricolums = new HashSet<SubjectCurricolum>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(80)]
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<SubjectCurricolum> SubjectCurricolums { get; set; }
    }
}
