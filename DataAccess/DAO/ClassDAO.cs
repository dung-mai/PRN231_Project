using BusinessObject.Models;

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

        public bool AddClass(Class newclass)
        {
            if (newclass != null)
            {
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
                oldClass.UpdatedAt = _class.UpdatedAt;
                oldClass.UpdatedBy = _class.UpdatedBy;
                oldClass.IsDelete = _class.IsDelete;
                return true;
            }
            return false;
        }
    }
}
