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

        public Student? GetStudentById(string rollNumber)
        {
            return _context.Students.FirstOrDefault(s => s.Rollnumber == rollNumber && s.IsDelete == false);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.Where(s => s.IsDelete == false).ToList();
        }

        public Boolean AddStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteStudent(string rollNumber)
        {
            try
            {
                Student? studentUpdate = GetStudentById(rollNumber);
                if (studentUpdate != null)
                {
                    studentUpdate.IsDelete = true;
                    _context.Students.Update(studentUpdate);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean UpdateStudent(Student student)
        {
            try
            {
                Student? studentUpdate = GetStudentById(student.Rollnumber);
                if (studentUpdate != null)
                {
                    studentUpdate.MajorId = student.MajorId;
                    studentUpdate.AccountId = student.AccountId;
                    studentUpdate.UpdatedAt = student.UpdatedAt;
                    studentUpdate.UpdatedBy = student.UpdatedBy;
                    studentUpdate.IsDelete = student.IsDelete;
                    _context.Students.Update(studentUpdate);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
