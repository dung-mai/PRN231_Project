namespace DTO.Request.Teacher
{
    public class TeacherUpdateDTO
    {
        public int AccountId { get; set; }
        public string TeacherCode { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
