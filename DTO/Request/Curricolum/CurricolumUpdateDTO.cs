namespace DTO.Request.Curricolum
{
    public class CurricolumUpdateDTO
    {
        public int Id { get; set; }
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
