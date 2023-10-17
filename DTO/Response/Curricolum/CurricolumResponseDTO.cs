using Bussiness.DTO;

namespace DTO.Response.Curricolum
{
    public class CurricolumResponseDTO
    {
        public int Id { get; set; }
        public string? CurricolumName { get; set; }
        public int? MajorId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
        public virtual MajorDTO? Major { get; set; }

    }
}
