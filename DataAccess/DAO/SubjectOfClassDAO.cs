﻿using BusinessObject.Models;
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
        public List<SubjectOfClass> GetTeachingClass(int teacherId)
        {
            return _context.SubjectOfClasses
                .Include(sc => sc.Subject)
                .Include(sc => sc.Class)
                .Where(sc => sc.TeacherId == teacherId && !sc.IsDelete)
                .ToList();
        }

        public bool IsTeachingClass(int classId, int teacherId)
        {
            return (_context.SubjectOfClasses.FirstOrDefault(sc => sc.TeacherId == teacherId && sc.Id == classId)) != null;
        }

        public List<SubjectOfClass> GetSubjectOfClasses()
        {
            return _context.SubjectOfClasses
                .Include(sc => sc.Subject)
                .Include(sc => sc.Class)
                .Include(sc => sc.Teacher)
                .ThenInclude(sc => sc.Account)
                .Include(sc => sc.StudyCourses)
                .ThenInclude(sc => sc.RollnumberNavigation)
                .Where(sc => !sc.IsDelete)
                .ToList();
        }

        public SubjectOfClass? GetSubjectOfClass(int id)
        {
            return _context.SubjectOfClasses
                .Include(sc => sc.Subject)
                .Include(sc => sc.Class)
                .Include(sc => sc.Teacher)
                .ThenInclude(sc => sc.Account)
                .Include(sc => sc.StudyCourses)
                .ThenInclude(sc => sc.RollnumberNavigation)
                .FirstOrDefault(sc => sc.Id == id && !sc.IsDelete);
        }

        public SubjectOfClass? GetSubjectOfClassLastIndex()
        {
            return _context.SubjectOfClasses
                .OrderBy(sc => sc.Id).LastOrDefault();
        }

        public bool AddSubjectOfClass(SubjectOfClass subjectOfClass)
        {
            if (subjectOfClass != null)
            {
                subjectOfClass.StudyCourses = null;
                subjectOfClass.Class = null;
                subjectOfClass.Teacher = null;
                subjectOfClass.Subject = null;
                _context.SubjectOfClasses.Add(subjectOfClass);
                return true;
            }
            return false;
        }

        public bool DeleteSubjectOfClass(int subjectOfClassId)
        {
            SubjectOfClass? subjectOfClass = _context.SubjectOfClasses.FirstOrDefault(sc => sc.Id == subjectOfClassId && !sc.IsDelete);
            if (subjectOfClass != null)
            {
                subjectOfClass.IsDelete = true;
                subjectOfClass.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool UpdateSubjectOfClass(SubjectOfClass _subjectOfClass)
        {
            SubjectOfClass? subjectOfClass = _context.SubjectOfClasses
                .FirstOrDefault(sc => sc.Id == _subjectOfClass.Id && !sc.IsDelete);
            if (subjectOfClass != null)
            {
                subjectOfClass.TeacherId = _subjectOfClass.TeacherId;
                subjectOfClass.SubjectId = _subjectOfClass.SubjectId != 0 ? _subjectOfClass.SubjectId : subjectOfClass.SubjectId;
                subjectOfClass.ClassId = _subjectOfClass.ClassId != 0 ? _subjectOfClass.ClassId : subjectOfClass.ClassId;
                //subjectOfClass.StartDate = _subjectOfClass.StartDate;
                //subjectOfClass.EndDate = _subjectOfClass.EndDate;
                subjectOfClass.UpdatedAt = DateTime.Now;
                //subjectOfClass.UpdatedBy = _subjectOfClass.UpdatedBy;
                subjectOfClass.IsDelete = _subjectOfClass.IsDelete;
                return true;
            }
            return false;
        }
    }
}
