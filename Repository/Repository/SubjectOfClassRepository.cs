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

        public IQueryable<SubjectOfClassResponseDTO> GetSubjectOfClasses()
        {
            SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
            List<SubjectOfClass> subjectOfClasss = subjectOfClassDAO.GetSubjectOfClasses();
            return subjectOfClasss.Select(sc => _mapper.Map<SubjectOfClassResponseDTO>(sc)).AsQueryable();
        }

        public bool SaveSubjectOfClass(SubjectOfClassCreateDTO subjectOfClass)
        {
            try
            {
                SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
                bool result = subjectOfClassDAO.AddSubjectOfClass(_mapper.Map<SubjectOfClass>(subjectOfClass));
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

        public bool UpdateSubjectOfClass(SubjectOfClassUpdateDTO subjectOfClass)
        {
            try
            {
                SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
                bool result = subjectOfClassDAO.UpdateSubjectOfClass(_mapper.Map<SubjectOfClass>(subjectOfClass));
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

        public bool SaveSubjectOfClassRes(SubjectOfClassResponseDTO subjectOfClassRes)
        {
            try
            {
                SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
                bool result = subjectOfClassDAO.AddSubjectOfClass(_mapper.Map<SubjectOfClass>(subjectOfClassRes));
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

        public SubjectOfClassResponseDTO? GetSubjectOfClassLastIndex()
        {
            SubjectOfClassDAO subjectOfClassDAO = new SubjectOfClassDAO(_context);
            return _mapper.Map<SubjectOfClassResponseDTO>(subjectOfClassDAO.GetSubjectOfClassLastIndex());
        }
    }
}
