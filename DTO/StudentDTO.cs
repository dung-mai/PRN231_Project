using DTO.Request.Account;

namespace Bussiness.DTO
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            StudyCourses = new HashSet<StudyCourseDTO>();
        }

        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }

        public virtual AccountResponseDTO? Account { get; set; }
        public virtual MajorDTO? Major { get; set; }
        public virtual ICollection<StudyCourseDTO> StudyCourses { get; set; }
        public List<SemesterDTO> GetSemesters()
        {
            List<SemesterDTO> semesters = new List<SemesterDTO>();
            StudyCourses.ToList().ForEach(course =>
            {
                SemesterDTO? semester = course?.SubjectOfClass?.Class?.Semester;
                if (semester != null && !checkExistedSemester(semesters,  semester))
                {
                    semesters.Add(semester);
                }
            });
            return semesters.OrderBy(s => s.Id).ToList();
        }

        public bool checkExistedSemester(List<SemesterDTO> semesters, SemesterDTO semester)
        {
            foreach (var s in semesters)
            {
                if (s.Id == semester.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
