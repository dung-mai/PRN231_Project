using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class SubjectOfClass
    {
        public SubjectOfClass()
        {
            StudyCourses = new HashSet<StudyCourse>();
        }
        [Key]
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Class? Class { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Account? Teacher { get; set; }
        public virtual ICollection<StudyCourse> StudyCourses { get; set; }
    }
}
