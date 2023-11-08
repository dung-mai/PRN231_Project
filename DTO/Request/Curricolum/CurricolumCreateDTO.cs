using DTO.Request.SubjectCurricolum;

namespace DTO.Request.Curricolum
{
    public class CurricolumCreateDTO
    {
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public List<SubjectCurricolumCreateDTO> Subjects { get; set; } = new List<SubjectCurricolumCreateDTO>();
    }
}
