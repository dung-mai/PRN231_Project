using Bussiness.DTO;

namespace DTO.Response.Class
{
    public class ClassReponseDTO
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public int? SemesterId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual SemesterDTO? Semester { get; set; }
    }
}
