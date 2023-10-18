using DTO.Request.Class;
using DTO.Response.Class;

namespace Repository.IRepository
{
    public interface IClassRepository
    {
        IQueryable<ClassResponseDTO> GetClasss();
        ClassResponseDTO? GetClass(int id);
        void UpdateClass(ClassUpdateDTO oldclass);
        bool SaveClass(ClassCreateDTO newclass);
        bool DeleteClass(int id);
    }
}
