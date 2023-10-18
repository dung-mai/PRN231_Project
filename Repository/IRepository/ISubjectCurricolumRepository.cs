using DTO.Request.SubjectCurricolum;
using DTO.Response.SubjectCurricolum;

namespace Repository.IRepository
{
    public interface ISubjectCurricolumRepository
    {
        IQueryable<SubjectCurricolumResponseDTO> GetSubjectCurricolums();
        SubjectCurricolumResponseDTO? GetSubjectCurricolum(int id);
        void UpdateSubjectCurricolum(SubjectCurricolumUpdateDTO subjectCurricolum);
        bool SaveSubjectCurricolum(SubjectCurricolumCreateDTO subjectCurricolum);
        bool DeleteSubjectCurricolum(int id);
    }
}
