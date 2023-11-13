using Bussiness.DTO;
using DTO.Response.DetailScore;
using DTO.Response.GradeComponent;
using DTO.Response.StudyCourse;

namespace DTO.Response.ClassGrade
{
    public class ClassGradeDTO
    {
        public int SubjectOfClassId { get; set; }
        public int GradeComponentId { get; set; }

        public GradeComponentResponseDTO GradeComponent { get; set; }
        public List<StudyCourseResponseDTO> Student { get; set; }

        public List<DetailScoreResponseDTO> DetailScores { get; set; }
    }
}
