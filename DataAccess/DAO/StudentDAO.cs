using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
            return _context.Students.Include(s => s.Account).FirstOrDefault(s => s.Rollnumber == rollNumber && s.IsDelete == false);
        }
        public Student? GetStudentByAccountId(int accountId)
        {
            return _context.Students.Include(s => s.Account).FirstOrDefault(s => s.AccountId == accountId && s.IsDelete == false);
        }

        public List<Student>? GetStudentByCurricolumnId(int curricolumnId)
        {
            return _context.Students.Include(s => s.Account).Where(s => s.CurricolumId == curricolumnId && s.IsDelete == false).ToList();
        }

        public List<Student> GetStudents()
        {
            return _context.Students.Include(s => s.Account).Where(s => s.IsDelete == false).ToList();
        }

        public Student? GetStudentLastIndex()
        {
            return _context.Students.OrderBy(s => s.Rollnumber).Include(s => s.Account).LastOrDefault();
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

        public string GetRollNumber(string major, string course)
        {
            Student? student = _context.Students.OrderBy(s => s.Rollnumber).LastOrDefault(s => s.Rollnumber.StartsWith($"{major}{course}"));
            if(student == null)
            {
                return $"{major}{course}0001";
            }
            string pattern = Regex.Escape($"{major}{course}") + @"(\d+)";
            Match match = Regex.Match(student.Rollnumber, pattern);
            int cacSoConLai = Int32.Parse(match.Groups[1].Value) + 1;
            string rollNumber = $"{cacSoConLai}".PadLeft(4, '0');
            return $"{major}{course}{rollNumber}";
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
                    studentUpdate.CurricolumId = student.CurricolumId;
                    studentUpdate.UpdatedAt = DateTime.Now;
                    studentUpdate.UpdatedBy = student.UpdatedBy;
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
