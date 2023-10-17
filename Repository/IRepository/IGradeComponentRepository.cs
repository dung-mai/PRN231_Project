namespace Repository.IRepository
{
    public interface IGradeComponentRepository
    {
        List<GradeComponentDTO> GetGradeComponentsOfSubjet(int classId);
        List<GradeComponentDTO> GetGradeComponentsOfSubjetWithStudentResult(int? subjectId, int studyCourseId);
    }
}
