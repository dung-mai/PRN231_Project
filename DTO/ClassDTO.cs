namespace Bussiness.DTO
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public virtual SemesterDTO? Semester { get; set; }
    }
}
