using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Class;
using DTO.Response.Class;
using Repository.IRepository;

namespace Repository.Repository
{
    public class ClassRepository : IClassRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public ClassRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteClass(int id)
        {
            try
            {
                ClassDAO classDAO = new ClassDAO(_context);
                classDAO.DeleteClass(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ClassResponseDTO? GetClass(int id)
        {
            ClassDAO classDAO = new ClassDAO(_context);
            return _mapper.Map<ClassResponseDTO>(classDAO.GetClass(id));
        }

        public IQueryable<ClassResponseDTO> GetClasses()
        {
            ClassDAO classDAO = new ClassDAO(_context);
            List<Class> classs = classDAO.GetClasses();
            return classs.Select(c => _mapper.Map<ClassResponseDTO>(c)).AsQueryable();
        }

        public bool SaveClass(ClassCreateDTO newclass)
        {
            try
            {
                ClassDAO classDAO = new ClassDAO(_context);
                bool result = classDAO.AddClass(_mapper.Map<Class>(newclass));
                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateClass(ClassUpdateDTO newclass)
        {
            try
            {
                ClassDAO classDAO = new ClassDAO(_context);
                bool result = classDAO.UpdateClass(_mapper.Map<Class>(newclass));
                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
