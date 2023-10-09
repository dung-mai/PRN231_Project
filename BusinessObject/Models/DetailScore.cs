namespace BusinessOject.Models
{
    public class DetailScore
    {
        public int Id { get; set; }
        public int? GradeComponentId { get; set; }
        public int? SubjectResultId { get; set; }
        public double? Mark { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Comment { get; set; }

        public virtual GradeComponent? GradeComponent { get; set; }
        public virtual SubjectResult? SubjectResult { get; set; }
    }
}
