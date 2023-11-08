using DTO.Request.SubjectCurricolum;
using DTO.Response.SubjectCurricolum;

namespace Repository.IRepository
{
    public interface ISubjectCurricolumRepository
    {
        IQueryable<SubjectCurricolumResponseDTO> GetSubjectCurricolums();
        SubjectCurricolumResponseDTO? GetSubjectCurricolum(int id);
        bool UpdateSubjectCurricolum(SubjectCurricolumUpdateDTO subjectCurricolum);
        bool SaveSubjectCurricolum(SubjectCurricolumCreateDTO subjectCurricolum);
        bool SaveSubjectCurricolumRange(List<SubjectCurricolumCreateDTO> subjectCurricolums);
        bool DeleteSubjectCurricolum(int id);
    }
}
