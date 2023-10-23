namespace DTO.Request.SubjectResult
{
    public class SubjectResultAddDTO
    {
        public int? StudyCourseId { get; set; }
        public int? TeacherId { get; set; }
        public double? AverageMark { get; set; }
        public short? Status { get; set; }
        public string? Note { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
