using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Teacher
    {
        public Teacher()
        {
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }

        [Key]
        public int AccountId { get; set; }
        [MaxLength(20)]
        public string TeacherCode { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Account? Account { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
