using DTO.Request.Major;
using DTO.Response.Major;

namespace Repository.IRepository
{
    public interface IMajorRepository
    {
        bool AddMajor(MajorAddDTO major);
        MajorResponseDTO? GetMajorById(int id);
        bool DeleteMajor(int id);
        bool UpdateMajor(MajorUpdateDTO major);
        List<MajorResponseDTO> GetMajors();
    }
}
