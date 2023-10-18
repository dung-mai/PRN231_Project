using DTO.Request.SubjectOfClass;
using DTO.Response.SubjectOfClass;

namespace Repository.IRepository
{
    public interface ISubjectOfClassRepository
    {
        List<SubjectOfClassResponseDTO> GetClassOfSemester(int id);
        List<SubjectOfClassResponseDTO> GetTeachingClass(int teacherId, int id);
        bool IsTeachingClass(int classId, int teacherId);
        IQueryable<SubjectOfClassResponseDTO> GetSubjectOfClasss();
        SubjectOfClassResponseDTO? GetSubjectOfClass(int id);
        void UpdateSubjectOfClass(SubjectOfClassUpdateDTO subjectOfClass);
        bool SaveSubjectOfClass(SubjectOfClassCreateDTO subjectOfClass);
        bool DeleteSubjectOfClass(int id);
    }
}
