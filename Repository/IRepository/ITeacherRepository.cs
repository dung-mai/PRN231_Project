using DTO.Request.Teacher;
using DTO.Response.Teacher;

namespace Repository.IRepository
{
    public interface ITeacherRepository
    {
        bool AddTeacher(TeacherAddDTO teacher);
        TeacherResponseDTO? GetTeacherById(int id);
        bool DeleteTeacher(int id);
        bool UpdateTeacher(TeacherUpdateDTO teacher);
        List<TeacherResponseDTO> GetTeachers();

        string GetTeacherCode(string namecut);
    }
}
