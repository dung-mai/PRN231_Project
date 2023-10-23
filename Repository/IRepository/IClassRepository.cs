using DTO.Request.Class;
using DTO.Response.Class;

namespace Repository.IRepository
{
    public interface IClassRepository
    {
        IQueryable<ClassResponseDTO> GetClasses();
        ClassResponseDTO? GetClass(int id);
        bool UpdateClass(ClassUpdateDTO oldclass);
        bool SaveClass(ClassCreateDTO newclass);
        bool DeleteClass(int id);
    }
}
