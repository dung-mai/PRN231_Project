using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class SubjectResultDAO
    {
        FAPDbContext _context;
        public SubjectResultDAO(FAPDbContext context)
        {
            _context = context;
        }


        public SubjectResult? GetSubjectResultById(int id)
        {
            return _context.SubjectResults
                 .Include(sr => sr.DetailScores)
                .Include(sr => sr.DetailScores)
                    .ThenInclude(dS => dS.GradeComponent)
                .FirstOrDefault(sr => sr.Id == id);
        }

        //public List<SubjectResult>? GetSubjectResultRollNumber(string rollnumber)
        //{
        //    return _context.SubjectResults.Where(sr => sr.Roll == id);
        //}

        public SubjectResult? GetSubjectResultByStudyCourse(int studyCourseId)
        {
            return _context.SubjectResults.FirstOrDefault(sr => sr.StudyCourseId == studyCourseId);
        }
        public List<SubjectResult> GetSubjectResults()
        {
            return _context.SubjectResults.Where(sr => sr.IsDelete == false).ToList();
        }

        public List<SubjectResult> GetSubjectResultsBy()
        {
            return _context.SubjectResults.Where(sr => sr.IsDelete == false).ToList();
        }

        public Boolean AddSubjectResult(SubjectResult subjectResult)
        {
            try
            {
                _context.SubjectResults.Add(subjectResult);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteSubjectResult(int id)
        {
            try
            {
                SubjectResult? subjectResultUpdate = GetSubjectResultById(id);
                if (subjectResultUpdate != null)
                {
                    subjectResultUpdate.IsDelete = true;
                    _context.SubjectResults.Remove(subjectResultUpdate);
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

        public Boolean UpdateSubjectResult(SubjectResult subjectResult)
        {
            try
            {
                SubjectResult? subjectResultUpdate = GetSubjectResultById(subjectResult.Id);
                if (subjectResultUpdate != null)
                {
                    subjectResultUpdate.StudyCourseId = subjectResult.StudyCourseId;
                    subjectResultUpdate.TeacherId = subjectResult.TeacherId;
                    subjectResultUpdate.AverageMark = subjectResult.AverageMark;
                    subjectResultUpdate.Status = subjectResult.Status;
                    subjectResultUpdate.Note = subjectResult.Note;
                    subjectResultUpdate.UpdatedAt = subjectResult.UpdatedAt;
                    subjectResultUpdate.UpdatedBy = subjectResult.UpdatedBy;
                    subjectResultUpdate.IsDelete = subjectResult.IsDelete;
                    _context.SubjectResults.Update(subjectResultUpdate);
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


        public Boolean UpdateSubjectResultMark(SubjectResult subjectResult)
        {
            try
            {
                SubjectResult? subjectResultUpdate = GetSubjectResultById(subjectResult.Id);
                subjectResultUpdate.StudyCourse = null;
                subjectResultUpdate.Teacher = null;
                if (subjectResultUpdate != null)
                {
                    subjectResultUpdate.AverageMark = subjectResult.AverageMark;
                    subjectResultUpdate.Status = subjectResult.Status;
                    _context.SubjectResults.Update(subjectResultUpdate);
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
