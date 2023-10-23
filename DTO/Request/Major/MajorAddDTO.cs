namespace DTO.Request.Major
{
    public class MajorAddDTO
    {
        public string? MajorName { get; set; }
        public string? MajorCode { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
