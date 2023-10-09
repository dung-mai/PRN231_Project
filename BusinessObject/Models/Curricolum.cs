namespace BusinessOject.Models
{
    public class Curricolum
    {
        public Curricolum()
        {
            SubjectCurricolums = new HashSet<SubjectCurricolum>();
        }

        public int Id { get; set; }
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<SubjectCurricolum> SubjectCurricolums { get; set; }
    }
}
