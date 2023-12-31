﻿using Bussiness.DTO;
using DTO.Response.SubjectOfClass;

namespace DTO.Response.Class
{
    public class ClassReponseAddDTO
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public int? SemesterId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<SubjectOfClassResponseDTO>? SubjectOfClasses { get; set; }
    }
}
