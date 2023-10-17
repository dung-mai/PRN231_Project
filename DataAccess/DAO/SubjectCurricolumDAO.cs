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
            return _context.SubjectCurricolums.ToList();
        }

        public SubjectCurricolum? GetSubjectCurricolum(int id)
        {
            return _context.SubjectCurricolums.FirstOrDefault(sc => sc.Id == id);
        }

        public int AddSubjectCurricolum(SubjectCurricolum subjectCurricolum)
        {
            if (subjectCurricolum != null)
            {
                _context.SubjectCurricolums.Add(subjectCurricolum);
                return 1;
            }
            return 0;
        }

        public int DeleteSubjectCurricolum(int subjectCurricolumId)
        {
            SubjectCurricolum? subjectCurricolum = _context.SubjectCurricolums.FirstOrDefault(sc => sc.Id == subjectCurricolumId);
            if (subjectCurricolum != null)
            {
                _context.SubjectCurricolums.Remove(subjectCurricolum);
                return 1;
            }
            return 0;
        }

        public int UpdateSubjectCurricolum(SubjectCurricolum _subjectCurricolum)
        {
            SubjectCurricolum? subjectCurricolum = _context.SubjectCurricolums
                .FirstOrDefault(sc => sc.Id == _subjectCurricolum.Id);
            if (subjectCurricolum != null)
            {
                subjectCurricolum.SubjectId = _subjectCurricolum.SubjectId;
                subjectCurricolum.CurricolumId = _subjectCurricolum.CurricolumId;
                subjectCurricolum.Status = _subjectCurricolum.Status;
                subjectCurricolum.TermNo = _subjectCurricolum.TermNo;
                subjectCurricolum.UpdatedAt = _subjectCurricolum.UpdatedAt;
                subjectCurricolum.UpdatedBy = _subjectCurricolum.UpdatedBy;
                subjectCurricolum.IsDelete = _subjectCurricolum.IsDelete;
                return 1;
            }
            return 0;
        }
    }
}
