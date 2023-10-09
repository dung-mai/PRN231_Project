using System.ComponentModel.DataAnnotations;

namespace BusinessOject.Models
{
    public class Class
    {
        public Class()
        {
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }
        [Key]
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
