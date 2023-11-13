using DTO.Request.StudyCourse;
using DTO.Response.StudyCourse;

namespace Repository.IRepository
{
    public interface IStudyCourseRepository
    {
        StudyCourseResponseDTO? GetStudyCourseBySubject(int? semesterId, string rollnumber, int? courseId);
        List<StudyCourseResponseDTO> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber);
        List<StudyCourseResponseAllDTO> GetStudyCourseByStudentRollnumber(string rolenumber);
        List<StudyCourseResponseDTO> GetStudyCourseByClass(int classId);
        List<StudyCourseResponseDTO> GetStudyCourseByStudent(int classId, string? rolenumber);
        //StudyCourseResponseDTO? GetSubjectClassById(int classId);
        IQueryable<StudyCourseResponseDTO> GetStudyCourses();
        StudyCourseResponseDTO? GetStudyCourse(int id);
        bool UpdateStudyCourse(StudyCourseUpdateDTO studyCourse);
        bool SaveStudyCourse(StudyCourseCreateDTO studyCourse);
        bool SaveStudyCourseRes(StudyCourseResponseDTO studyCourse);

        bool DeleteStudyCourse(int id);
    }
}
