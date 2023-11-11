using DTO.Response.Account;
using DTO.Response.Curricolum;
using DTO.Response.Major;

namespace DTO.Response.Student
{
    public class StudentResponseStudyCourseDTO
    {
        public string Rollnumber { get; set; } = null!;
        public int? AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

    }
}
