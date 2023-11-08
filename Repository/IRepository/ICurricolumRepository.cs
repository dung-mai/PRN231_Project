using DTO.Request.Curricolum;
using DTO.Response.Curricolum;

namespace Repository.IRepository
{
    public interface ICurricolumRepository
    {
        IQueryable<CurricolumResponseDTO> GetCurricolums();
        CurricolumResponseDTO? GetCurricolum(int id);
        int GetRecentlyAddCurricolum();
        bool UpdateCurricolum(CurricolumUpdateDTO curricolum);
        bool SaveCurricolum(CurricolumCreateDTO curricolum);
        bool DeleteCurricolum(int id);
    }
}
