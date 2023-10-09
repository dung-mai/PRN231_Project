namespace BusinessObject.Models
{
    public class SubjectOfClass
    {
        public SubjectOfClass()
        {
            StudyCourses = new HashSet<StudyCourse>();
        }

        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Account? Teacher { get; set; }
        public virtual ICollection<StudyCourse> StudyCourses { get; set; }
    }
}
