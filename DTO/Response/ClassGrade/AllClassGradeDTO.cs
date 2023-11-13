using Bussiness.DTO;
using DTO.Response.DetailScore;
using DTO.Response.SubjectResult;

namespace DTO.Response.ClassGrade
{
    public class AllClassGradeDTO
    {
        public int SubjectOfClassId { get; set; }
        public SubjectResultResponseDTO SubjectResult { get; set; }
        public List<DetailScoreResponseDTO> DetailScores { get; set; }

        public bool status { get; set; } = false;
    }
}
