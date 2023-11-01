using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Major
    {
        public Major()
        {
            Curricolums = new HashSet<Curricolum>();
            Students = new HashSet<Student>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? MajorName { get; set; }
        [MaxLength(20)]
        public string? MajorCode { get; set; }
        [MaxLength(5)]
        public string? StudentIdentityCode { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<Curricolum> Curricolums { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
