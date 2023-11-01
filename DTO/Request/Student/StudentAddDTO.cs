using DTO.Request.Account;
using DTO.Response.Account;

namespace DTO.Request.Student
{
    public class StudentAddDTO
    {
        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
        public virtual AccountCreateStudentDTO? Account { get; set; }
    }
}
