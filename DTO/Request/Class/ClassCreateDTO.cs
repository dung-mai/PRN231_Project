namespace DTO.Request.Class
{
    public class ClassCreateDTO
    {
        public string? ClassName { get; set; }
        public int? SemesterId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
