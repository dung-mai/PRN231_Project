using BusinessObject.Models;

namespace DataAccess.Managers
{
    public class SemesterDAO
    {
        FAPDbContext _context;
        public SemesterDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<Semester> GetAllSemester()
        {
            return _context.Semesters.ToList();
        }

        public Semester? GetCurrentSemester()
        {
            return _context.Semesters.FirstOrDefault(s => DateTime.Compare((DateTime)s.EndDate, DateTime.Now) >= 0 );
        }

        public List<Semester> GetTeachingSemester(int teacherId)
        {
            return _context.Semesters.Where(s => s.Classes.FirstOrDefault(c => 
                                                        (c.SubjectOfClasses.FirstOrDefault(s => s.TeacherId == teacherId) != null)) != null)
                                    .ToList();
        }
    }
}
