using BusinessObject.Models;

namespace DataAccess.Managers
{
    public class GradeComponentDAO
    {
        FAPDbContext _context;
        public GradeComponentDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<GradeComponent> GetGradeComponentsOfSubject(int subjectId)
        {
            return _context.GradeComponents
                .Where(c => c.SubjectId == subjectId)
                .ToList();
        }
    }
}
