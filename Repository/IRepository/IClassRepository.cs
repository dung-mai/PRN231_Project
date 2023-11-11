using DTO.Request.Class;
using DTO.Response.Class;

namespace Repository.IRepository
{
    public interface IClassRepository
    {
        IQueryable<ClassResponseDTO> GetClasses();
        IQueryable<ClassReponseAddDTO> GetClassesAdd();
        ClassResponseDTO? GetClass(int id);
        ClassResponseDTO? GetClassLastIndex();
        List<ClassResponseDTO> AddClass(int numberOfClass, string className, int semesterId);
        bool UpdateClass(ClassUpdateDTO oldclass);
        bool SaveClass(ClassCreateDTO newclass);
        bool AddClassRes(ClassReponseAddDTO newclass);
        bool DeleteClass(int id);
    }
}
