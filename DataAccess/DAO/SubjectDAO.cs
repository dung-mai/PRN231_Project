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
            return _context.Subjects.ToList();
        }

        public Subject? GetSubject(int id)
        {
            return _context.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public int AddSubject(Subject subject)
        {
            if (subject != null)
            {
                _context.Subjects.Add(subject);
                return 1;
            }
            return 0;
        }

        public int DeleteSubject(int subjectId)
        {
            Subject? subject = _context.Subjects.FirstOrDefault(s => s.Id == subjectId);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                return 1;
            }
            return 0;
        }

        public int UpdateSubject(Subject _subject)
        {
            Subject? subject = _context.Subjects
                .FirstOrDefault(s => s.Id == _subject.Id);
            if (subject != null)
            {
                subject.SubjectName = _subject.SubjectName;
                subject.SubjectCode = _subject.SubjectCode;
                subject.DateOfIssues = _subject.DateOfIssues;
                subject.NumOfCredits = _subject.NumOfCredits;
                subject.TermNo = _subject.TermNo;
                subject.Status = _subject.Status;
                subject.UpdatedAt = _subject.UpdatedAt;
                subject.UpdatedBy = _subject.UpdatedBy;
                subject.IsDelete = _subject.IsDelete;
                return 1;
            }
            return 0;
        }
    }
}
