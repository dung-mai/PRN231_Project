namespace DTO.Request.Subject
{
    public class SubjectUpdateDTO
    {
        public int Id { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public DateTime? DateOfIssues { get; set; }
        public short? NumOfCredits { get; set; }
        public short? TermNo { get; set; }
        public short? Status { get; set; } = 1;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
