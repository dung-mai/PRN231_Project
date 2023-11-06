using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
            return _context.Teachers.Include(t=> t.Account).FirstOrDefault(t => t.AccountId == id && t.IsDelete == false);
        }

        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.Include(t => t.Account).Where(t => t.IsDelete == false).ToList();
        }

        public Boolean AddTeacher(Teacher teacher)
        {
            try
            {
                teacher.Account = null;
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteTeacher(int id)
        {
            try
            {
                Teacher? teacherUpdate = GetTeacherById(id);
                if (teacherUpdate != null)
                {
                    teacherUpdate.IsDelete = true;
                    _context.Teachers.Remove(teacherUpdate);
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

        public string GetTeacherCode(string nameCut)
        {
            string pattern = @$"{nameCut}[^p]";
            List<Teacher> teachers = _context.Teachers
               .Include(t => t.Account)
               .OrderBy(s => s.TeacherCode)
               .ToList();
            List<Teacher> test = teachers.Where(s => Regex.IsMatch(s.Account.Email, pattern)).ToList();
            int count = test.Count;
            if(count == 0 ){
                return $"{nameCut}";
            }
            string teacherCode = $"{nameCut}{count}";
            return teacherCode;
        }
    }
}
