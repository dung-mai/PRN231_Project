using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class GradeComponentDTO
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string? GradeCategory { get; set; }
        public string? GradeItem { get; set; }
        public bool? IsFinal { get; set; }
        public decimal? Weight { get; set; }
        public short? MinScore { get; set; }

        public virtual SubjectDTO? Subject { get; set; }
        public DetailScoreDTO? DetailScore { get; set; }

        public int GetNumberOfItemInCategory(List<GradeComponentDTO> gradeComponentDTOs)
        {
            int numberOfItemInCategory = 0;
            foreach (GradeComponentDTO gradeComponent in gradeComponentDTOs)
            {
                if (gradeComponent.GradeCategory == this.GradeCategory)
                {
                    numberOfItemInCategory++;
                }
            }
            return numberOfItemInCategory;
        }

        public double? GetAverageCategoryScore(List<GradeComponentDTO> gradeComponentDTOs)
        {
            double totalScoreOfCategoryGrade = 0;
            int numberOfItemInCategory = 0;
            foreach (GradeComponentDTO gradeComponent in gradeComponentDTOs)
            {
                if (gradeComponent.GradeCategory == this.GradeCategory)
                {
                    numberOfItemInCategory++;
                    if (gradeComponent.DetailScore != null && gradeComponent.DetailScore.Mark.HasValue)
                    {
                        totalScoreOfCategoryGrade += (double) gradeComponent.DetailScore.Mark;
                    } else
                    {
                        return null;
                    }
                }
            }
            return Math.Round(totalScoreOfCategoryGrade / numberOfItemInCategory, 1);
        }
    }
}
