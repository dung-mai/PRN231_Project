using Bussiness.DTO;
using DTO.Response.Student;

namespace DTO.Response.StudyCourse
{
    public class StudyCourseResponseDTO
    {
        public string? Rollnumber { get; set; }
        public int? SubjectOfClassId { get; set; }
        public short? TryTime { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; } =DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
        public virtual StudentResponseStudyCourseDTO? RollnumberNavigation { get; set; }
    }
}
