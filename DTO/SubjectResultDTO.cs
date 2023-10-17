using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class SubjectResultDTO
    {
        public int Id { get; set; }
        public int? StudyCourseId { get; set; }
        public double? AverageMark { get; set; }
        public short? Status { get; set; }
        public string? Note { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public virtual StudyCourseDTO? StudyCourse { get; set; }
        public virtual ICollection<DetailScoreDTO> DetailScores { get; set; }

        public String GetStatus()
        {
            switch (Status) { 
                case 1:
                    return "Studying";
                case 2:
                    return "Not yet";
                case 3:
                    return "Passed";
                case 4:
                    return "Failed";
            }
            return "";
        }
    }
}
