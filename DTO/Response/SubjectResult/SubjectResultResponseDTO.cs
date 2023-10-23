using BusinessObject.Models;
using DTO.Response.StudyCourse;
using DTO.Response.Teacher;

namespace DTO.Response.SubjectResult
{
    public class SubjectResultResponseDTO
    {
        public int Id { get; set; }
        public int? StudyCourseId { get; set; }
        public int? TeacherId { get; set; }
        public double? AverageMark { get; set; }
        public short? Status { get; set; }
        public string? Note { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual StudyCourseResponseDTO? StudyCourse { get; set; }
        public virtual TeacherResponseDTO? Teacher { get; set; }
    }
}
