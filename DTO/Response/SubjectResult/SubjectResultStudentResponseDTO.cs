using BusinessObject.Models;
using DTO.Response.DetailScore;
using DTO.Response.StudyCourse;
using DTO.Response.Teacher;

namespace DTO.Response.SubjectResult
{
    public class SubjectResultStudentResponseDTO
    {
        public int? Id { get; set; }
        public int? StudyCourseId { get; set; }
        public double? AverageMark { get; set; }
        public short? Status { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<DetailScoreResponseDTO> DetailScores { get; set; }
    }
}
