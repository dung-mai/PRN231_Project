using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class SubjectOfClassDAO
    {
        FAPDbContext _context;
        public SubjectOfClassDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<SubjectOfClass> GetClassOfSemester(int semesterId)
        {
            return _context.SubjectOfClasses
                            .Include(sc => sc.Subject)
                            .Include(sc => sc.Class)
                            .Where(sc => sc.Class.SemesterId == semesterId)
                            .ToList();
        }

        public SubjectOfClass? GetSubjectClassById(int subjectClassId)
        {
            return _context.SubjectOfClasses
                .Include(sc => sc.Subject)
                .Include(sc => sc.Class)
                .FirstOrDefault(c => c.Id == subjectClassId);
        }

        public List<SubjectOfClass> GetTeachingClass(int teacherId, int semesterId)
        {
            return _context.SubjectOfClasses
                .Include(sc => sc.Subject)
                .Include(sc => sc.Class)
                .Where(sc => sc.TeacherId == teacherId && sc.Class.SemesterId == semesterId)
                .ToList();
        }

        public bool IsTeachingClass(int classId, int teacherId)
        {
            return (_context.SubjectOfClasses.FirstOrDefault(sc => sc.TeacherId == teacherId && sc.Id == classId)) != null;
        }
    }
}
