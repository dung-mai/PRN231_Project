using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class DetailScoreDAO
    {
        FAPDbContext _context;
        public DetailScoreDAO(FAPDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdateScore(DetailScore detailScoreInput)
        {
            var detailScore =  _context.DetailScores
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
                                                                && s.GradeComponentId == itemId );
        }

        public List<DetailScore> GetScoresByStudyResult(int studyCourse) {
            return _context.DetailScores.Where(course => course.SubjectResult.StudyCourseId == studyCourse).ToList();
        }
    }
}
