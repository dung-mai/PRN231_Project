using BusinessObject.Models;
using DTO.Request.SubjectOfClass;
using DTO.Response.SubjectOfClass;

namespace Repository.IRepository
{
    public interface ISubjectOfClassRepository
    {
        List<SubjectOfClassResponseDTO> GetClassOfSemester(int id);
        List<SubjectOfClassResponseDTO> GetTeachingClass(int teacherId, int id);
        List<SubjectOfClassResponseDTO> GetTeachingClass(int teacherId);
        bool IsTeachingClass(int classId, int teacherId);
        IQueryable<SubjectOfClassResponseDTO> GetSubjectOfClasses();
        SubjectOfClassResponseDTO? GetSubjectOfClass(int id);
        SubjectOfClassResponseDTO? GetSubjectOfClassLastIndex();
        bool UpdateSubjectOfClass(SubjectOfClassUpdateDTO subjectOfClass);
        bool SaveSubjectOfClass(SubjectOfClassCreateDTO subjectOfClass);
        bool SaveSubjectOfClassRes(SubjectOfClassResponseDTO subjectOfClassRes);
        bool DeleteSubjectOfClass(int id);
    }
}
