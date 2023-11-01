using DTO.Response.Account;
using DTO.Response.Major;

namespace DTO.Response.Student
{
    public class StudentResponseDTO
    {
        public string Rollnumber { get; set; } = null!;
        public string AcademicYear { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual AccountResponseDTO? Account { get; set; }
        public virtual MajorResponseDTO? Major { get; set; }
    }
}
