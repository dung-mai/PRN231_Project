namespace DTO.Request.Teacher
{
    public class TeacherAddDTO
    {
        public string TeacherCode { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
