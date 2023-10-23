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


        public Semester? GetSemesterById(int id)
        {
            return _context.Semesters.FirstOrDefault(s => s.Id == id);
        }

        public List<Semester> GetSemesters()
        {
            return _context.Semesters.ToList();
        }

        public Boolean AddSemester(Semester semester)
        {
            try
            {
                _context.Semesters.Add(semester);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteSemester(Semester semester)
        {
            try
            {
                _context.Semesters.Remove(semester);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean UpdateSemester(Semester semester)
        {
            try
            {
                Semester? semesterUpdate = GetSemesterById(semester.Id);
                if (semesterUpdate != null)
                {
                    semesterUpdate.Year = semester.Year;
                    semesterUpdate.SemesterName = semester.SemesterName;
                    semesterUpdate.StartDate = semester.StartDate;
                    semesterUpdate.EndDate = semester.EndDate;
                    semesterUpdate.UpdatedAt = semester.UpdatedAt;
                    semesterUpdate.UpdatedAt = semester.UpdatedAt;
                    semesterUpdate.UpdatedBy = semester.UpdatedBy;
                    semesterUpdate.IsDelete = semester.IsDelete;
                    _context.Semesters.Update(semesterUpdate);
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
