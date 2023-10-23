using DTO.Request.SubjectResult;
using DTO.Response.SubjectResult;

namespace Repository.IRepository
{
    public interface ISubjectResultRepository
    {
        bool AddSubjectResult(SubjectResultAddDTO subjectResult);
        SubjectResultResponseDTO? GetSubjectResultById(int id);
        bool DeleteSubjectResult(int id);
        bool UpdateSubjectResult(SubjectResultUpdateDTO subjectResult);
        List<SubjectResultResponseDTO> GetSubjectResults();
    }
}
