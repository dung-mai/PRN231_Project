using DTO.Request.Subject;
using DTO.Response.Subject;

namespace Repository.IRepository
{
    public interface ISubjectRepository
    {
        IQueryable<SubjectResponseDTO> GetSubjects();
        SubjectResponseDTO? GetSubject(int id);
        bool UpdateSubject(SubjectUpdateDTO subject);
        bool SaveSubject(SubjectCreateDTO subject);
        bool DeleteSubject(int id);
    }
}
