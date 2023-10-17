using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class CurricolumDAO
    {
        FAPDbContext _context;
        public CurricolumDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<Curricolum> GetCurricolums()
        {
            return _context.Curricolums.ToList();
        }

        public Curricolum? GetCurricolum(int id)
        {
            return _context.Curricolums.FirstOrDefault(c => c.Id == id);
        }

        public int AddCurricolum(Curricolum curricolum)
        {
            if (curricolum != null)
            {
                _context.Curricolums.Add(curricolum);
                return 1;
            }
            return 0;
        }

        public int DeleteCurricolum(int curricolumId)
        {
            Curricolum? curricolum = _context.Curricolums.FirstOrDefault(c => c.Id == curricolumId);
            if (curricolum != null)
            {
                _context.Curricolums.Remove(curricolum);
                return 1;
            }
            return 0;
        }

        public int UpdateCurricolum(Curricolum _curricolum)
        {
            Curricolum? curricolum = _context.Curricolums
                .FirstOrDefault(c => c.Id == _curricolum.Id);
            if (curricolum != null)
            {
                curricolum.CurricolumName = _curricolum.CurricolumName;
                curricolum.MajorId = _curricolum.MajorId;
                curricolum.UpdatedAt = _curricolum.UpdatedAt;
                curricolum.UpdatedBy = _curricolum.UpdatedBy;
                curricolum.IsDelete = _curricolum.IsDelete;
                return 1;
            }
            return 0;
        }
    }
}
