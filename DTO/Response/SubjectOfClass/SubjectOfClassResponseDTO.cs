using BusinessObject.Models;
using Bussiness.DTO;
using DTO.Response.Teacher;

namespace DTO.Response.SubjectOfClass
{
    public class SubjectOfClassResponseDTO
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ClassDTO? Class { get; set; }
        public virtual SubjectDTO? Subject { get; set; }
        public virtual TeacherResponseDTO? Teacher { get; set; }
    }
}
