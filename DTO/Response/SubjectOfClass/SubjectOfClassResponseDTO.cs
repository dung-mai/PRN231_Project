using DTO.Response.StudyCourse;

namespace DTO.Response.SubjectOfClass
{
    public class SubjectOfClassResponseDTO
    {
        public int? Id { get; set; } = 0;
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectCode { get; set; }
        public int? TeacherCode { get; set; }
        public string? TeacherName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<StudyCourseResponseDTO>? StudyCourses { get; set; }
    }
}
