using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Curricolums
                .Include(c => c.Major)
                .Where(c => !c.IsDelete)
                .ToList();
        }

        public Curricolum? GetCurricolum(int id)
        {
            return _context.Curricolums
                .Include(c => c.Major)
                .FirstOrDefault(c => c.Id == id && !c.IsDelete);
        }

        public bool AddCurricolum(Curricolum curricolum)
        {
            if (curricolum != null)
            {
                _context.Curricolums.Add(curricolum);
                return true;
            }
            return false;
        }

        public bool DeleteCurricolum(int curricolumId)
        {
            Curricolum? curricolum = _context.Curricolums.FirstOrDefault(c => c.Id == curricolumId && !c.IsDelete);
            if (curricolum != null)
            {
                curricolum.IsDelete = true;
                curricolum.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool UpdateCurricolum(Curricolum _curricolum)
        {
            Curricolum? curricolum = _context.Curricolums
                .FirstOrDefault(c => c.Id == _curricolum.Id);
            if (curricolum != null)
            {
                curricolum.CurricolumName = _curricolum.CurricolumName;
                curricolum.MajorId = _curricolum.MajorId;
                curricolum.UpdatedAt = DateTime.Now;
                curricolum.UpdatedBy = _curricolum.UpdatedBy;
                curricolum.IsDelete = _curricolum.IsDelete;
                return true;
            }
            return false;
        }
    }
}
