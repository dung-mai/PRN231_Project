using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.Student
{
    public class StudentUpdateDTO
    {
        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
