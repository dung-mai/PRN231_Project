using BusinessObject.Models;

namespace DataAccess.Managers
{
    public class GradeComponentDAO
    {
        FAPDbContext _context;
        public GradeComponentDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<GradeComponent> GetGradeComponentsOfSubject(int subjectId)
        {
            return _context.GradeComponents
                .Where(c => c.SubjectId == subjectId)
                .ToList();
        }

        public GradeComponent? GetGradeComponentById(int id)
        {
            return _context.GradeComponents
                .FirstOrDefault(gc => gc.Id == id && gc.IsDelete == false);
        }


        public List<GradeComponent> GetGradeComponents()
        {
            return _context.GradeComponents.Where(gc => !gc.IsDelete).ToList();
        }

        public List<GradeComponent> GetGradeComponentsBySubject(int subjectId)
        {
            return _context.GradeComponents.Where(gc => !gc.IsDelete && gc.SubjectId == subjectId).ToList();
        }

        public Boolean AddGradeComponent(GradeComponent gradeComponent)
        {
            try
            {
                _context.GradeComponents.Add(gradeComponent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean DeleteGradeComponent(int id)
        {
            try
            {
                GradeComponent? gradeComponentUpdate = GetGradeComponentById(id);
                if (gradeComponentUpdate != null)
                {
                    gradeComponentUpdate.IsDelete = true;
                    _context.GradeComponents.Update(gradeComponentUpdate);
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

        public Boolean UpdateGradeComponent(GradeComponent gradeComponent)
        {
            try
            {
                GradeComponent? gradeComponentUpdate = GetGradeComponentById(gradeComponent.Id);
                if (gradeComponentUpdate != null)
                {
                    gradeComponentUpdate.SubjectId = gradeComponent.SubjectId;
                    gradeComponentUpdate.GradeCategory = gradeComponent.GradeCategory;
                    gradeComponentUpdate.GradeItem = gradeComponent.GradeItem;
                    gradeComponentUpdate.IsFinal = gradeComponent.IsFinal;
                    gradeComponentUpdate.Weight = gradeComponent.Weight;
                    gradeComponentUpdate.MinScore = gradeComponent.MinScore;
                    gradeComponentUpdate.FinalScoreId = gradeComponent.FinalScoreId;
                    gradeComponentUpdate.UpdatedAt = gradeComponent.UpdatedAt;
                    gradeComponentUpdate.UpdatedBy = gradeComponent.UpdatedBy;
                    gradeComponentUpdate.IsDelete = gradeComponent.IsDelete;
                    _context.GradeComponents.Update(gradeComponentUpdate);
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

        public bool SaveGradeComponentRange(List<GradeComponent> gradeComponents)
        {
            try
            {
                _context.GradeComponents.AddRange(gradeComponents);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public GradeComponent? GetFinalExamOfSbject(int subjectId)
        {
            return _context.GradeComponents.FirstOrDefault(gc => gc.SubjectId == subjectId && gc.GradeCategory == "Final Exam" && gc.IsDelete == false);
        }

        public void SetFinalExamRef(int subjectId, int finalExamId)
        {
            try
            {
                GradeComponent? gradeComponentUpdate = _context.GradeComponents.FirstOrDefault(gc => gc.SubjectId == subjectId && gc.GradeCategory == "Final Exam Resit" && gc.IsDelete == false); ;
                if (gradeComponentUpdate != null)
                {
                    gradeComponentUpdate.FinalScoreId = finalExamId;
                    _context.GradeComponents.Update(gradeComponentUpdate);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
