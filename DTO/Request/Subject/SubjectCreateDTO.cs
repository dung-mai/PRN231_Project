using DTO.Request.GradeComponent;

namespace DTO.Request.Subject
{
    public class SubjectCreateDTO
    {
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public DateTime? DateOfIssues { get; set; }
        public short? NumOfCredits { get; set; }
        public short? TermNo { get; set; }
        public short? Status { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public List<GradeComponentAddDTO> GradeComponents { get; set; } = new List<GradeComponentAddDTO>();
    }
}
