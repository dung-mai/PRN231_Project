using DTO.Request.GradeComponent;
using DTO.Response.GradeComponent;

namespace Repository.IRepository
{
    public interface IGradeComponentRepository
    {
        List<GradeComponentResponseDTO> GetGradeComponentsOfSubjet(int classId);
        List<GradeComponentResponseDTO> GetGradeComponentsOfSubjetWithStudentResult(int? subjectId, int studyCourseId);

        bool AddGradeComponent(GradeComponentAddDTO gradeComponent);
        GradeComponentResponseDTO? GetGradeComponentById(int id);
        bool DeleteGradeComponent(int id);
        bool UpdateGradeComponent(GradeComponentUpdateDTO gradeComponent);
        List<GradeComponentResponseDTO> GetGradeComponents();
        bool SaveGradeComponentRange(List<GradeComponentAddDTO> gradeComponents);
    }
}
