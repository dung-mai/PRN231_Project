﻿using BusinessObject.Models;
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


    }
}