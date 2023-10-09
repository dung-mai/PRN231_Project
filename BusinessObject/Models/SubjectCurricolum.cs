namespace BusinessObject.Models
{
    public partial class SubjectCurricolum
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? CurricolumId { get; set; }
        public bool? Status { get; set; }
        public short? TermNo { get; set; }

        public virtual Curricolum? Curricolum { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
