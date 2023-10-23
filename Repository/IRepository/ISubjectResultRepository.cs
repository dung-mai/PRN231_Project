using DTO.Request.SubjectResult;
using DTO.Response.SubjectResult;

namespace Repository.IRepository
{
    public interface ISubjectResultRepository
    {
        bool AddSubjectResult(SubjectResultAddDTO subjectResult);
        SubjectResultResponseDTO? GetSubjectResultById(int id);
        bool DeleteSubjectResult(SubjectResultUpdateDTO subjectResult);
        bool UpdateSubjectResult(SubjectResultUpdateDTO subjectResult);
        List<SubjectResultResponseDTO> GetSubjectResults();
    }
}
