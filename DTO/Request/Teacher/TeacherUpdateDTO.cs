using DTO.Request.Account;

namespace DTO.Request.Teacher
{
    public class TeacherUpdateDTO
    {
        public int AccountId { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; } = 1;
        public bool IsDelete { get; set; } = false;
        public virtual AccountUpdateTeacherDTO Account { get; set; }
    }
}
