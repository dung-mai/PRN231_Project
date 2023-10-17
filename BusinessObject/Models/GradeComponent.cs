using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class GradeComponent
    {
        public GradeComponent()
        {
            DetailScores = new HashSet<DetailScore>();
            InverseFinalScore = new HashSet<GradeComponent>();
        }
        [Key]
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        [MaxLength(50)]
        public string? GradeCategory { get; set; }
        [MaxLength(50)]
        public string? GradeItem { get; set; }
        public bool? IsFinal { get; set; }
        public decimal? Weight { get; set; }
        public short? MinScore { get; set; }
        public int? FinalScoreId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual GradeComponent? FinalScore { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<DetailScore> DetailScores { get; set; }
        public virtual ICollection<GradeComponent> InverseFinalScore { get; set; }
    }
}
