namespace Repository.IRepository
{
    public interface IStudentRepository
    {
        StudentDTO? GetStudentWithGradeResults(int accountId);
    }
}
