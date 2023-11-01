using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class MajorDAO
    {
        FAPDbContext _context;
        public MajorDAO(FAPDbContext context)
        {
            _context = context;
        }


        public Major? GetMajorById(int id)
        {
            return _context.Majors.FirstOrDefault(m => m.Id == id && m.IsDelete == false);
        }

        public List<Major> GetMajors()
        {
            return _context.Majors.Where(m => m.IsDelete == false).ToList();
        }

        public Boolean AddMajor(Major major)
        {
            try
            {
                _context.Majors.Add(major);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteMajor(int id)
        {
            try
            {
                Major? majorUpdate = GetMajorById(id);
                if (majorUpdate != null)
                {
                    majorUpdate.IsDelete = true;
                    majorUpdate.UpdatedAt = DateTime.Now;
                    _context.Majors.Update(majorUpdate);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean UpdateMajor(Major major)
        {
            try
            {
                Major? majorUpdate = GetMajorById(major.Id);
                if (majorUpdate != null)
                {
                    majorUpdate.MajorName = major.MajorName;
                    majorUpdate.MajorCode = major.MajorCode;
                    majorUpdate.UpdatedAt = DateTime.Now;
                    majorUpdate.UpdatedBy = major.UpdatedBy;
                    majorUpdate.IsDelete = major.IsDelete;
                    _context.Majors.Update(majorUpdate);
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
