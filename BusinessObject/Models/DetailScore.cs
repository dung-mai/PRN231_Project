﻿using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class DetailScore
    {
        [Key]
        public int Id { get; set; }
        public int? GradeComponentId { get; set; }
        public int? SubjectResultId { get; set; }
        public double? Mark { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        [MaxLength(200)]
        public string? Comment { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual GradeComponent? GradeComponent { get; set; }
        public virtual SubjectResult? SubjectResult { get; set; }
    }
}
