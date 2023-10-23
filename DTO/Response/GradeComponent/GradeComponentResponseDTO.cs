namespace DTO.Response.GradeComponent
{
    public class GradeComponentResponseDTO
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string? GradeCategory { get; set; }
        public string? GradeItem { get; set; }
        public bool? IsFinal { get; set; }
        public decimal? Weight { get; set; }
        public short? MinScore { get; set; }
        public int? FinalScoreId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}
