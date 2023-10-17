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

        public List<Class> GetClasss()
        {
            return _context.Classes.ToList();
        }

        public Class? GetClass(int id)
        {
            return _context.Classes.FirstOrDefault(c => c.Id == id);
        }

        public int AddClass(Class newclass)
        {
            if (newclass != null)
            {
                _context.Classes.Add(newclass);
                return 1;
            }
            return 0;
        }

        public int DeleteClass(int classId)
        {
            Class? classToDeleted = _context.Classes.FirstOrDefault(c => c.Id == classId);
            if (classToDeleted != null)
            {
                _context.Classes.Remove(classToDeleted);
                return 1;
            }
            return 0;
        }

        public int UpdateClass(Class _class)
        {
            Class? oldClass = _context.Classes
                .FirstOrDefault(c => c.Id == _class.Id);
            if (oldClass != null)
            {
                oldClass.ClassName = _class.ClassName;
                oldClass.SemesterId = _class.SemesterId;
                oldClass.UpdatedAt = _class.UpdatedAt;
                oldClass.UpdatedBy = _class.UpdatedBy;
                oldClass.IsDelete = _class.IsDelete;
                return 1;
            }
            return 0;
        }
    }
}
