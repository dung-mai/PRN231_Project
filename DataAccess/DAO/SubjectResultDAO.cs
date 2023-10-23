using BusinessObject.Models;

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
            return _context.SubjectResults.FirstOrDefault(sr => sr.Id == id);
        }

        public List<SubjectResult> GetSubjectResults()
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
    }
}
