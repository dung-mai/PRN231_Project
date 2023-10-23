using DTO.Request.Student;
using DTO.Response.Student;

namespace Repository.IRepository
{
    public interface IStudentRepository
    {
        //StudentDTO? GetStudentWithGradeResults(int accountId);
        bool AddStudent(StudentAddDTO student);
        StudentResponseDTO? GetStudentById(string roleNumber);
        bool DeleteStudent(StudentUpdateDTO student);
        bool UpdateStudent(StudentUpdateDTO student);
        List<StudentResponseDTO> GetStudents();
    }
}
