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

        public List<SubjectOfClass> GetSubjectOfClasss()
        {
            return _context.SubjectOfClasses.ToList();
        }

        public SubjectOfClass? GetSubjectOfClass(int id)
        {
            return _context.SubjectOfClasses.FirstOrDefault(sc => sc.Id == id);
        }

        public int AddSubjectOfClass(SubjectOfClass subjectOfClass)
        {
            if (subjectOfClass != null)
            {
                _context.SubjectOfClasses.Add(subjectOfClass);
                return 1;
            }
            return 0;
        }

        public int DeleteSubjectOfClass(int subjectOfClassId)
        {
            SubjectOfClass? subjectOfClass = _context.SubjectOfClasses.FirstOrDefault(sc => sc.Id == subjectOfClassId);
            if (subjectOfClass != null)
            {
                _context.SubjectOfClasses.Remove(subjectOfClass);
                return 1;
            }
            return 0;
        }

        public int UpdateSubjectOfClass(SubjectOfClass _subjectOfClass)
        {
            SubjectOfClass? subjectOfClass = _context.SubjectOfClasses
                .FirstOrDefault(sc => sc.Id == _subjectOfClass.Id);
            if (subjectOfClass != null)
            {
                subjectOfClass.TeacherId = _subjectOfClass.TeacherId;
                subjectOfClass.SubjectId = _subjectOfClass.SubjectId;
                subjectOfClass.ClassId = _subjectOfClass.ClassId;
                subjectOfClass.StartDate = _subjectOfClass.StartDate;
                subjectOfClass.EndDate = _subjectOfClass.EndDate;
                subjectOfClass.UpdatedAt = _subjectOfClass.UpdatedAt;
                subjectOfClass.UpdatedBy = _subjectOfClass.UpdatedBy;
                subjectOfClass.IsDelete = _subjectOfClass.IsDelete;
                return 1;
            }
            return 0;
        }
    }
}
