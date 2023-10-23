using System.ComponentModel.DataAnnotations;

namespace DTO.Request.DetailScore
{
    public class DetailScoreUpdateDTO
    {
        public int Id { get; set; }
        public int? GradeComponentId { get; set; }
        public int? SubjectResultId { get; set; }
        public double? Mark { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Comment { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
