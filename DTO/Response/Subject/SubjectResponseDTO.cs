<<<<<<< HEAD
﻿using DTO.Response.GradeComponent;
=======
﻿using DTO.Request.GradeComponent;
using DTO.Request.SubjectCurricolum;
>>>>>>> 201647e (subject CRUD + fix major crud)

namespace DTO.Response.Subject
{
    public class SubjectResponseDTO
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
<<<<<<< HEAD
        public virtual ICollection<GradeComponentResponseDTO>? GradeComponents { get; set; }
=======

        public List<GradeComponentUpdateDTO> GradeComponents { get; set; } = new List<GradeComponentUpdateDTO>();
>>>>>>> 201647e (subject CRUD + fix major crud)
    }
}
