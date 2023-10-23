using DTO.Request.Semester;
using DTO.Response.Semester;

namespace Repository.IRepository
{
    public interface ISemesterRepository
    {
        //List<SemesterDTO> GetAllSemester();
        //SemesterDTO? GetCurrentSemester();
        //List<SemesterDTO> GetTeachSemester(int id);

        bool AddSemester(SemesterAddDTO semester);
        SemesterResponseDTO? GetSemesterById(int id);
        bool DeleteSemester(int id);
        bool UpdateSemester(SemesterUpdateDTO semester);
        List<SemesterResponseDTO> GetSemesters();
    }
}
