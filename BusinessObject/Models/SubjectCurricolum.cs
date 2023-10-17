using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public partial class SubjectCurricolum
    {
        [Key]
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? CurricolumId { get; set; }
        public bool? Status { get; set; }
        public short? TermNo { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual Curricolum? Curricolum { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
