using DTO.Request.Student;
using DTO.Response.Student;

namespace Repository.IRepository
{
    public interface IStudentRepository
    {
        //StudentDTO? GetStudentWithGradeResults(int accountId);
        bool AddStudent(StudentAddDTO student);
        StudentResponseDTO? GetStudentById(string roleNumber);

        StudentResponseDTO? GetStudentLastIndex();
        bool DeleteStudent(string roleNumber);
        bool UpdateStudent(StudentUpdateDTO student);
        List<StudentResponseDTO> GetStudents();
        List<StudentResponseDTO> GetStudentsByCurricoulmnId(int curricoulmnId);
        string GetRoleNumber(string major, string course);
    }
}
