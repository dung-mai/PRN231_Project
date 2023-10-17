using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Managers
{
    public class StudentDAO
    {
        FAPDbContext _context;
        public StudentDAO(FAPDbContext context)
        { 
            _context = context;
        }

        public Student? GetStudentWithGradeResults(int id)
        {
            return _context.Students.Include(s => s.Account)
                                    .Include(s => s.StudyCourses)
                                        .ThenInclude(course => course.SubjectResults)
                                    .Include(s => s.StudyCourses)
                                        .ThenInclude(course => course.SubjectOfClass)
                                        .ThenInclude(classSubject => classSubject.Subject)
                                    .Include(s => s.StudyCourses)
                                        .ThenInclude(course => course.SubjectOfClass)
                                        .ThenInclude(classSubject => classSubject.Class)
                                        .ThenInclude(c => c.Semester)
                                    .FirstOrDefault(s => s.AccountId == id);
        }
    }
}
