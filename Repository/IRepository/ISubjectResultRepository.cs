using BusinessObject.Models;
using DTO.Request.SubjectResult;
using DTO.Response.StudyCourse;
using DTO.Response.SubjectResult;

namespace Repository.IRepository
{
    public interface ISubjectResultRepository
    {
        bool AddSubjectResult(SubjectResultAddDTO subjectResult);
        SubjectResultResponseDTO? GetSubjectResultById(int id);
        SubjectResultStudentResponseDTO? GetSubjectResultStudentById(int id);
        bool DeleteSubjectResult(int id);
        bool UpdateSubjectResult(SubjectResultUpdateDTO subjectResult);
        bool UpdateSubjectResultMark(SubjectResultResponseDTO subjectResult);
        List<SubjectResultResponseDTO> GetSubjectResults();
        void CreateResultOfClass(int subjectClassId);
    }
}
