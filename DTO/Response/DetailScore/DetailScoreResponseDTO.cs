using BusinessObject.Models;
using Bussiness.DTO;
using DTO.Response.GradeComponent;
using DTO.Response.SubjectResult;
using System.ComponentModel.DataAnnotations;

namespace DTO.Response.DetailScore
{
    public class DetailScoreResponseDTO
    {
        public int? Id { get; set; }
        public int? GradeComponentId { get; set; }
        public int? SubjectResultId { get; set; }
        public double? Mark { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; } 
        [MaxLength(200)]
        public string? Comment { get; set; } = "";
        public bool IsDelete { get; set; } = false;

        public virtual GradeComponentResponseDTO? GradeComponent { get; set; }
        public virtual SubjectResultResponseDTO? SubjectResult { get; set; }
    }
}
