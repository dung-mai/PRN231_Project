using BusinessObject.Models;
using System.Text.RegularExpressions;

namespace DataAccess.DAO
{
    public class ClassDAO
    {
        FAPDbContext _context;
        public ClassDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<Class> GetClasses()
        {
            return _context.Classes
                .Where(c => !c.IsDelete)
                .ToList();
        }

        public Class? GetClass(int id)
        {
            return _context.Classes.FirstOrDefault(c => c.Id == id && !c.IsDelete);
        }

        public Class? GetClassLastIndex()
        {
            return _context.Classes.OrderBy(c => c.Id).LastOrDefault();
        }

        public bool AddClass(Class newclass)
        {
            if (newclass != null)
            {
                newclass.SubjectOfClasses = null;
                _context.Classes.Add(newclass);
                return true;
            }
            return false;
        }

        public bool DeleteClass(int classId)
        {
            Class? classToDeleted = _context.Classes.FirstOrDefault(c => c.Id == classId && !c.IsDelete);
            if (classToDeleted != null)
            {
                classToDeleted.UpdatedAt = DateTime.Now;
                classToDeleted.IsDelete = true;
                return true;
            }
            return false;
        }

        public bool UpdateClass(Class _class)
        {
            Class? oldClass = _context.Classes
                .FirstOrDefault(c => c.Id == _class.Id && !c.IsDelete);
            if (oldClass != null)
            {
                oldClass.ClassName = _class.ClassName;
                oldClass.SemesterId = _class.SemesterId;
                oldClass.UpdatedAt = DateTime.Now;
                oldClass.UpdatedBy = _class.UpdatedBy;
                oldClass.IsDelete = _class.IsDelete;
                return true;
            }
            return false;
        }

        public List<Class> AddClass(int numberOfClass, string className, int semesterId)
        {
            List<Class> classes = new List<Class>();
            Class? @class = _context.Classes.OrderBy(s => s.Id).LastOrDefault(s => s.ClassName.StartsWith($"{className}"));
            if (@class == null)
            {
                string firstClass = $"{className}01";
                Class newClass = new Class()
                {
                    ClassName = $"{firstClass}",
                    SemesterId = semesterId,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = 0,
                    IsDelete = false,
                };
                classes.Add(newClass);
                for (int i = 0; i < numberOfClass-1; i++)
                {
                    string hauTo = $"{i + 2}".PadLeft(2, '0');
                    newClass = new Class()
                    {
                        ClassName = $"{className}{hauTo}",
                        SemesterId = semesterId,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = 0,
                        IsDelete = false,
                    };
                    classes.Add(newClass);
                }

            }
            else
            {
                string pattern = Regex.Escape($"{className}") + @"(\d+)";
                Match match = Regex.Match(@class.ClassName, pattern);
                int cacSoConLai = Int32.Parse(match.Groups[1].Value) + 1;
                for (int i = 0; i < numberOfClass; i++)
                {
                    string hauTo = $"{cacSoConLai}".PadLeft(2, '0');
                    Class newClass = new Class()
                    {
                        ClassName = $"{className}{hauTo}",
                        SemesterId = semesterId,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = 0,
                        IsDelete = false,
                    };
                    cacSoConLai++;
                    classes.Add(newClass);
                }

            }
            return classes;
        }
    }
}
