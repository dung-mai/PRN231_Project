using System.ComponentModel.DataAnnotations;

namespace DTO.Request.Teacher
{
    public class TeacherUpdateDTO
    {
        public int AccountId { get; set; }
        [MaxLength(20)]
        public string TeacherCode { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
