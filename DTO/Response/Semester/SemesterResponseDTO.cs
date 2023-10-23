namespace DTO.Response.Semester
{
    public class SemesterResponseDTO
    {
        public int Id { get; set; }
        public short? Year { get; set; }
        public string? SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
