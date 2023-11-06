using DTO.Request.Account;

namespace DTO.Request.Teacher
{
    public class TeacherAddDTO
    {
        public int AccountId { get; set; } = 0;
        public string TeacherCode { get; set; } = "";
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual AccountCreateTeacherDTO? Account { get; set; }
    }
}
