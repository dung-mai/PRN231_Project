using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DataAccess.DAO
{
    public class DetailScoreDAO
    {
        FAPDbContext _context;
        public DetailScoreDAO(FAPDbContext context)
        {
            _context = context;
        }

        public DetailScore? GetGetDetailScoreById(int id)
        {
            return _context.DetailScores.Include(ds => ds.GradeComponent).Include(ds => ds.SubjectResult).FirstOrDefault(ds => ds.Id == id && ds.IsDelete == false);
        }

        public DetailScore? GetDetailScoreByGradeComponentIdSubjectResultId(int gradeComponentId, int subjectResultId)
        {
            return _context.DetailScores
                .Include(ds => ds.GradeComponent)
                .Include(ds => ds.SubjectResult)
                .FirstOrDefault(ds => ds.GradeComponentId == gradeComponentId && ds.SubjectResultId == subjectResultId);

        }

        public List<DetailScore>? GetDetailScoreBySubjectResultId(int subjectResultId)
        {
            return _context.DetailScores
                .Include(ds => ds.GradeComponent)
                .Include(ds => ds.SubjectResult)
                .Where(ds =>  ds.SubjectResultId == subjectResultId).ToList();
        }
        public List<DetailScore> GetDetailScores()
        {
            return _context.DetailScores.Include(ds => ds.GradeComponent).Include(ds => ds.SubjectResult).Where(ds => ds.IsDelete == false).ToList();
        }

        public Boolean AddDetailScore(DetailScore detailScore)
        {
            try
            {
                _context.DetailScores.Add(detailScore);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteDetailScore(int id)
        {
            DetailScore? detailScoreUpdate = GetGetDetailScoreById(id);
            try
            {
                if (detailScoreUpdate != null)
                {
                    detailScoreUpdate.IsDelete = true;
                    _context.DetailScores.Update(detailScoreUpdate);
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

        public Boolean UpdateDetailScore(DetailScore detailScore)
        {
            try
            {
                DetailScore? detailScoreUpdate = GetGetDetailScoreById(detailScore.Id);
                if (detailScoreUpdate != null)
                {
                    detailScoreUpdate.Mark = detailScore.Mark;
                    detailScoreUpdate.UpdatedAt = detailScore.UpdatedAt;
                    detailScoreUpdate.UpdatedBy = detailScore.UpdatedBy;
                    detailScoreUpdate.Comment = detailScore.Comment;
                    detailScoreUpdate.IsDelete = detailScore.IsDelete;
                    _context.DetailScores.Update(detailScoreUpdate);
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
        public Boolean UpdateDetailScoreMark(DetailScore detailScore, int gid, int sId)
        {
            try
            {
                DetailScore? detailScoreUpdate = GetGetDetailScoreById(detailScore.Id);
                if (detailScoreUpdate != null)
                {
                    detailScoreUpdate.Mark = detailScore.Mark;
                    detailScoreUpdate.Comment = detailScore.Comment;

                    // Reassign the original values of GradeComponentId and SubjectResultId
                    detailScoreUpdate.GradeComponentId = gid;
                    detailScoreUpdate.SubjectResultId = sId;

                    _context.DetailScores.Update(detailScoreUpdate);
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




        //

        public void AddOrUpdateScore(DetailScore detailScoreInput)
        {
            var detailScore = _context.DetailScores
                                .FirstOrDefault(m => m.Id == detailScoreInput.Id);

            if (detailScore != null)
            {
                detailScore.Mark = detailScoreInput.Mark;
                detailScore.Comment = detailScoreInput.Comment;
            }
            else
            {
                var newDetailScore = new DetailScore
                {
                    GradeComponentId = detailScoreInput.GradeComponentId,
                    SubjectResultId = detailScoreInput.SubjectResultId,
                    Mark = detailScoreInput.Mark,
                    Comment = detailScoreInput.Comment
                };

                _context.DetailScores.Add(newDetailScore);
            }
        }

        public DetailScore? FindScore(string rollnumber, int classId, int itemId)
        {
            return _context.DetailScores.FirstOrDefault(s => s.SubjectResult.StudyCourse.Rollnumber == rollnumber
                                                                && s.SubjectResult.StudyCourse.SubjectOfClassId == classId
                                                                && s.GradeComponentId == itemId);
        }

        public List<DetailScore> GetScoresByStudyResult(int studyCourse)
        {
            return _context.DetailScores.Where(course => course.SubjectResult.StudyCourseId == studyCourse).ToList();
        }
    }
}
