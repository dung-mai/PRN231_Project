namespace Repository.IRepository
{
    public interface ISemesterRepository
    {
        List<SemesterDTO> GetAllSemester();
        SemesterDTO? GetCurrentSemester();
        List<SemesterDTO> GetTeachSemester(int id);
    }
}
