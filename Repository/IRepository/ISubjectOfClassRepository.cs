namespace Repository.IRepository
{
    public interface ISubjectOfClassRepository
    {
        List<SubjectOfClassDTO> GetClassOfSemester(int id);
        List<SubjectOfClassDTO> GetTeachingClass(int teacherId, int id);
        bool IsTeachingClass(int classId, int teacherId);
    }
}
