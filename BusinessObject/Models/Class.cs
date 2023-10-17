using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Class
    {
        public Class()
        {
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? ClassName { get; set; }
        public int? SemesterId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Semester? Semester { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
