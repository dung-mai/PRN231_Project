using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.SubjectOfClass;
using DTO.Response.SubjectOfClass;
using Repository.IRepository;

namespace Repository.Repository
{
    public class SubjectOfClassRepository : ISubjectOfClassRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public SubjectOfClassRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SubjectOfClassResponseDTO> GetClassOfSemester(int semesterId)
        {
            SubjectOfClassDAO manager = new SubjectOfClassDAO(_context);
            return manager.GetClassOfSemester(semesterId).Select(sc => _mapper.Map<SubjectOfClassResponseDTO>(sc)).ToList();
        }

        public List<SubjectOfClassResponseDTO> GetTeachingClass(int teacherId, int semesterId)
        {
            SubjectOfClassDAO manager = new SubjectOfClassDAO(_context);
            return manager.GetTeachingClass(teacherId, semesterId).Select(sc => _mapper.Map<SubjectOfClassResponseDTO>(sc)).ToList();
        }

        public bool IsTeachingClass(int classId, int teacherId)
        {
            SubjectOfClassDAO manager = new SubjectOfClassDAO(_context);
            return manager.IsTeachingClass(classId, teacherId);
        }

        public bool DeleteSubjectOfClass(int id)
        {
            try
            {
                SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
                subjectOfClassDAO.DeleteSubjectOfClass(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SubjectOfClassResponseDTO? GetSubjectOfClass(int id)
        {
            SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
            return _mapper.Map<SubjectOfClassResponseDTO>(subjectOfClassDAO.GetSubjectOfClass(id));
        }

        public IQueryable<SubjectOfClassResponseDTO> GetSubjectOfClasss()
        {
            SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
            List<SubjectOfClass> subjectOfClasss = subjectOfClassDAO.GetSubjectOfClasss();
            return subjectOfClasss.Select(sc => _mapper.Map<SubjectOfClassResponseDTO>(sc)).AsQueryable();
        }

        public bool SaveSubjectOfClass(SubjectOfClassCreateDTO subjectOfClass)
        {
            try
            {
                SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
                int result = subjectOfClassDAO.AddSubjectOfClass(_mapper.Map<SubjectOfClass>(subjectOfClass));
                if (result > 0)
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

        public void UpdateSubjectOfClass(SubjectOfClassUpdateDTO subjectOfClass)
        {
            SubjectOfClassDAO subjectOfClassDAO = new(_context);
            subjectOfClassDAO.UpdateSubjectOfClass(_mapper.Map<SubjectOfClass>(subjectOfClass));
            _context.SaveChanges();
        }
    }
}
