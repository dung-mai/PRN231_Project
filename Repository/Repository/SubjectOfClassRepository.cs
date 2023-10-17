using AutoMapper;
using BusinessObject.Models;
using Bussiness.DTO;
using DataAccess.DAO;
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

        public List<SubjectOfClassDTO> GetClassOfSemester(int semesterId)
        {
            SubjectOfClassDAO manager = new SubjectOfClassDAO(_context);
            return manager.GetClassOfSemester(semesterId).Select(sc => _mapper.Map<SubjectOfClassDTO>(sc)).ToList();
        }

        public List<SubjectOfClassDTO> GetTeachingClass(int teacherId, int semesterId)
        {
            SubjectOfClassDAO manager = new SubjectOfClassDAO(_context);
            return manager.GetTeachingClass(teacherId, semesterId).Select(sc => _mapper.Map<SubjectOfClassDTO>(sc)).ToList();
        }

        public bool IsTeachingClass(int classId, int teacherId)
        {
            SubjectOfClassDAO manager = new SubjectOfClassDAO(_context);
            return manager.IsTeachingClass(classId, teacherId);
        }
    }
}
