using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class StudyCourseDAO
    {
        FAPDbContext _context;
        public StudyCourseDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<StudyCourse> GetStudyCourseByClass(int classId)
        {
            return _context.StudyCourses
                            .Include(course => course.SubjectResults)
                                .ThenInclude(sr => sr.DetailScores)
                            .Include(course => course.RollnumberNavigation)
                                .ThenInclude(student => student.Account)
                           .Where(course => course.SubjectOfClassId == classId).ToList();
        }

        public IEnumerable<object> GetStudyCourseByStudent(int classId, string rolenumber)
        {
            return _context.StudyCourses
                                        .Include(course => course.SubjectResults)
                                            .ThenInclude(sr => sr.DetailScores)
                                        .Include(course => course.RollnumberNavigation)
                                            .ThenInclude(student => student.Account)
                                       .Where(course => course.SubjectOfClassId == classId
                                                    && course.Rollnumber.ToLower() == rolenumber.ToLower()).ToList();
        }

        public List<StudyCourse> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber)
        {
            return _context.StudyCourses
                .Include(course => course.SubjectOfClass)
                    .ThenInclude(sc => sc.Class)
                .Where(course => course.Rollnumber == rollNumber &&
                                                        course.SubjectOfClass.Class.SemesterId == semesterId)
                                        .ToList();
        }


        public StudyCourse? GetStudyCourseOfStudentBySubject(int semesterId, string rollNumber, int courseId)
        {
            return _context.StudyCourses
               .Include(course => course.SubjectOfClass)
                   .ThenInclude(sc => sc.Class)
                .Include(course => course.SubjectResults)
               .FirstOrDefault(course => course.Rollnumber == rollNumber &&
                                                       course.SubjectOfClass.Class.SemesterId == semesterId
                                                       && course.SubjectOfClass.SubjectId == courseId);
        }

        public void RecountAverage(List<StudyCourse> studyCourses)
        {
            foreach (StudyCourse studyCourse in studyCourses)
            {
                // _context.StudyCourses
            }
        }

        public double CountAverage(StudyCourse studyCourse)
        {
            double total = 0;
            if (studyCourse.SubjectResults.Count > 0)
            {
                studyCourse.SubjectResults.ToList()[0].DetailScores.ToList().ForEach(score =>
                {
                    if (score.Mark.HasValue)
                    {
                        total += ((double)score.Mark * (double)score.GradeComponent.Weight / 100);
                    }
                });
            }
            return total;
        }

        public List<StudyCourse> GetStudyCourses()
        {
            return _context.StudyCourses.ToList();
        }

        public StudyCourse? GetStudyCourse(int id)
        {
            return _context.StudyCourses.FirstOrDefault(sc => sc.Id == id);
        }

        public int AddStudyCourse(StudyCourse studyCourse)
        {
            if (studyCourse != null)
            {
                _context.StudyCourses.Add(studyCourse);
                return 1;
            }
            return 0;
        }

        public int DeleteStudyCourse(int studyCourseId)
        {
            StudyCourse? studyCourse = _context.StudyCourses.FirstOrDefault(sc => sc.Id == studyCourseId);
            if (studyCourse != null)
            {
                _context.StudyCourses.Remove(studyCourse);
                return 1;
            }
            return 0;
        }

        public int UpdateStudyCourse(StudyCourse _studyCourse)
        {
            StudyCourse? studyCourse = _context.StudyCourses
                .FirstOrDefault(sc => sc.Id == _studyCourse.Id);
            if (studyCourse != null)
            {
                studyCourse.Rollnumber = _studyCourse.Rollnumber;
                studyCourse.SubjectOfClassId = _studyCourse.SubjectOfClassId;
                studyCourse.TryTime = _studyCourse.TryTime;
                studyCourse.UpdatedAt = _studyCourse.UpdatedAt;
                studyCourse.UpdatedBy = _studyCourse.UpdatedBy;
                studyCourse.IsDelete = _studyCourse.IsDelete;
                return 1;
            }
            return 0;
        }

    }
}
