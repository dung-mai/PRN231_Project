namespace DTO.Request.Major
{
    public class MajorUpdateDTO
    {
        public int Id { get; set; }
        public string? MajorName { get; set; }
        public string? MajorCode { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
