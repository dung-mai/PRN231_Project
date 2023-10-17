namespace Repository.IRepository
{
    public interface IStudyCourseRepository
    {
        StudyCourseDTO? GetStudyCourseBySubject(int? semesterId, string rollnumber, int? courseId);
        List<StudyCourseDTO> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber);
        List<StudyCourseDTO> GetStudyCourseByClass(int classId);
        List<StudyCourseDTO> GetStudyCourseByStudent(int classId, string? rolenumber);
        SubjectOfClassDTO? GetSubjectClassById(int classId);
    }
}
