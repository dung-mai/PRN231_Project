using DTO.Request.Account;

namespace DTO.Request.Student
{
    public class StudentUpdateDTO
    {
        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; } = 1;
        public virtual AccountUpdateStudentDTO Account { get; set; }
    }
}
