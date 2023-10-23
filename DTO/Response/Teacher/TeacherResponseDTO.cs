using DTO.Response.Account;

namespace DTO.Response.Teacher
{
    public class TeacherResponseDTO
    {
        public int AccountId { get; set; }
        public string TeacherCode { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual AccountResponseDTO? Account { get; set; }
    }
}
