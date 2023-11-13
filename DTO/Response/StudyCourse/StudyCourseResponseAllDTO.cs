using Bussiness.DTO;
using DTO.Response.Student;
using DTO.Response.Subject;
using DTO.Response.SubjectOfClass;
using DTO.Response.SubjectResult;

namespace DTO.Response.StudyCourse
{
    public class StudyCourseResponseAllDTO
    {
        public int? Id { get; set; } = 0;
        public string? Rollnumber { get; set; }
        public int? SubjectOfClassId { get; set; }
        public short? TryTime { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; } =DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
        public virtual StudentResponseStudyCourseDTO? RollnumberNavigation { get; set; }
        public virtual SubjectOfClassResponseDTO? SubjectOfClass { get; set; }
        public virtual ICollection<SubjectResultResponseDTO> SubjectResults { get; set; }
    }
}
