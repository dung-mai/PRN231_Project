using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Account
    {
        public Account()
        {
            Students = new HashSet<Student>();
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Email { get; set; } = null!;
        [MaxLength(30)]
        public string Password { get; set; } = null!;
        public int Roleid { get; set; }
        [MaxLength(12)]
        public string? Phonenumber { get; set; }
        public bool? Gender { get; set; }
        [MaxLength(12)] 
        public string IdCard { get; set; } = null!;
        public DateTime? Dob { get; set; }
        [MaxLength(10)]
        public string Firstname { get; set; } = null!;
        [MaxLength(10)]
        public string Lastname { get; set; } = null!;
        [MaxLength(10)]
        public string Middlename { get; set; } = null!;
        [MaxLength(150)]
        public string? Address { get; set; }
        [MaxLength(150)]
        public string? Image { get; set; }
        public short Status { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
