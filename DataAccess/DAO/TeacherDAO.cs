using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class TeacherDAO
    {
        FAPDbContext _context;
        public TeacherDAO(FAPDbContext context)
        {
            _context = context;
        }


        public Teacher? GetTeacherById(int id)
        {
            return _context.Teachers.FirstOrDefault(m => m.AccountId == id);
        }

        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Boolean AddTeacher(Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteTeacher(Teacher teacher)
        {
            try
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean UpdateTeacher(Teacher teacher)
        {
            try
            {
                Teacher? teacherUpdate = GetTeacherById(teacher.AccountId);
                if (teacherUpdate != null)
                {
                    teacherUpdate.TeacherCode = teacher.TeacherCode;
                    teacherUpdate.UpdatedAt = teacher.UpdatedAt;
                    teacherUpdate.UpdatedBy = teacher.UpdatedBy;
                    teacherUpdate.IsDelete = teacher.IsDelete;
                    _context.Teachers.Update(teacherUpdate);
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
