using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.GradeComponents.FirstOrDefault(gc => gc.Id == id);
        }

        public List<GradeComponent> GetGradeComponents()
        {
            return _context.GradeComponents.ToList();
        }

        public Boolean AddGradeComponent(GradeComponent gradeComponent)
        {
            try
            {
                _context.GradeComponents.Add(gradeComponent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteGradeComponent(GradeComponent gradeComponent)
        {
            try
            {
                _context.GradeComponents.Remove(gradeComponent);
                _context.SaveChanges();
                return true;
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
    }
}
