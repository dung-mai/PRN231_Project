using DTO.Response.Subject;

namespace DTO.Request.SubjectCurricolum
{
    public class SubjectCurricolumUpdateDTO
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? CurricolumId { get; set; }
        public bool? Status { get; set; }
        public short? TermNo { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
        public SubjectResponseDTO? Subject { get; set; }
    }
}
