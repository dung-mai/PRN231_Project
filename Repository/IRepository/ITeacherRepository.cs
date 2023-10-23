using DTO.Request.Teacher;
using DTO.Response.Teacher;

namespace Repository.IRepository
{
    public interface ITeacherRepository
    {
        bool AddTeacher(TeacherAddDTO teacher);
        TeacherResponseDTO? GetTeacherById(int id);
        bool DeleteTeacher(TeacherUpdateDTO teacher);
        bool UpdateTeacher(TeacherUpdateDTO teacher);
        List<TeacherResponseDTO> GetTeachers();
    }
}
