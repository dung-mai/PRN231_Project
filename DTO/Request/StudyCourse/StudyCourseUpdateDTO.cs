namespace DTO.Request.StudyCourse
{
    public class StudyCourseUpdateDTO
    {
        public int Id { get; set; }
        public string? Rollnumber { get; set; }
        public int? SubjectOfClassId { get; set; }
        public short? TryTime { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
