using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class SubjectCurricolumDAO
    {
        FAPDbContext _context;
        public SubjectCurricolumDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<SubjectCurricolum> GetSubjectCurricolums()
        {
            return _context.SubjectCurricolums
                .Where(sc => !sc.IsDelete)
                .ToList();
        }

        public SubjectCurricolum? GetSubjectCurricolum(int id)
        {
            return _context.SubjectCurricolums
                .FirstOrDefault(sc => sc.Id == id && !sc.IsDelete);
        }

        public bool AddSubjectCurricolum(SubjectCurricolum subjectCurricolum)
        {
            if (subjectCurricolum != null)
            {
                _context.SubjectCurricolums.Add(subjectCurricolum);
                return true;
            }
            return false;
        }

        public bool DeleteSubjectCurricolum(int subjectCurricolumId)
        {
            SubjectCurricolum? subjectCurricolum = _context.SubjectCurricolums.FirstOrDefault(sc => sc.Id == subjectCurricolumId && !sc.IsDelete);
            if (subjectCurricolum != null)
            {
                subjectCurricolum.IsDelete = true;
                subjectCurricolum.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool UpdateSubjectCurricolum(SubjectCurricolum _subjectCurricolum)
        {
            SubjectCurricolum? subjectCurricolum = _context.SubjectCurricolums
                .FirstOrDefault(sc => sc.Id == _subjectCurricolum.Id && !sc.IsDelete);
            if (subjectCurricolum != null)
            {
                subjectCurricolum.SubjectId = _subjectCurricolum.SubjectId;
                subjectCurricolum.CurricolumId = _subjectCurricolum.CurricolumId;
                subjectCurricolum.Status = _subjectCurricolum.Status;
                subjectCurricolum.TermNo = _subjectCurricolum.TermNo;
                subjectCurricolum.UpdatedAt = DateTime.Now;
                subjectCurricolum.UpdatedBy = _subjectCurricolum.UpdatedBy;
                subjectCurricolum.IsDelete = _subjectCurricolum.IsDelete;
                return true;
            }
            return false;
        }

        public bool AddSubjectCurricolumRange(List<SubjectCurricolum> subjectCurricolums)
        {
            if (subjectCurricolums != null && subjectCurricolums.Count > 0)
            {
                _context.SubjectCurricolums.AddRange(subjectCurricolums);
                return true;
            }
            return false;
        }

        public List<SubjectCurricolum> GetSubjectCurricolumsById(int id)
        {
            return _context.SubjectCurricolums
                .Where(sc => !sc.IsDelete && sc.CurricolumId == id)
                .ToList();
        }
    }
}
