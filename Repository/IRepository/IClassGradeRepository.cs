using DTO.Response.ClassGrade;

namespace Repository.IRepository
{
    public interface IClassGradeRepository
    {
        ClassGradeDTO GetData(int classSubjectId, int gradeId);
        List<AllClassGradeDTO> GetListClassAllSubjectResult(int classSubjectId);
    }
}
