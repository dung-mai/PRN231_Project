using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class SubjectDAO
    {
        FAPDbContext _context;

        public SubjectDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<Subject> GetSubjects()
        {
            return _context.Subjects
                .Where(s => !s.IsDelete)
                .ToList();
        }

        public Subject? GetSubject(int id)
        {
            return _context.Subjects
                .FirstOrDefault(s => s.Id == id && !s.IsDelete);
        }

        public bool AddSubject(Subject subject)
        {
            if (subject != null)
            {
                _context.Subjects.Add(subject);
                return true;
            }
            return false;
        }

        public bool DeleteSubject(int subjectId)
        {
            Subject? subject = _context.Subjects.FirstOrDefault(s => s.Id == subjectId && !s.IsDelete);
            if (subject != null)
            {
                subject.IsDelete = true;
                subject.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool UpdateSubject(Subject _subject)
        {
            Subject? subject = _context.Subjects
                .FirstOrDefault(s => s.Id == _subject.Id && !s.IsDelete);
            if (subject != null)
            {
                subject.SubjectName = _subject.SubjectName;
                subject.SubjectCode = _subject.SubjectCode;
                subject.DateOfIssues = _subject.DateOfIssues;
                subject.NumOfCredits = _subject.NumOfCredits;
                subject.TermNo = _subject.TermNo;
                subject.Status = _subject.Status;
                subject.UpdatedAt = DateTime.Now;
                subject.UpdatedBy = _subject.UpdatedBy;
                subject.IsDelete = _subject.IsDelete;
                return true;
            }
            return false;
        }
    }
}
