using AutoMapper;
using BusinessObject.Models;
using DataAccess.Managers;
using Repository.IRepository;

namespace Repository.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public SemesterRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SemesterDTO> GetAllSemester()
        {
            SemesterDAO semesterDAO = new SemesterDAO(_context);
            return semesterDAO.GetAllSemester().Select(semester => _mapper.Map<SemesterDTO>(semester)).ToList();
        }

        public SemesterDTO? GetCurrentSemester()
        {
            SemesterDAO semesterDAO = new SemesterDAO(_context);
            Semester? semester = semesterDAO.GetCurrentSemester();
            return semester != null ? _mapper.Map<SemesterDTO>(semester) : null;
        }

        public List<SemesterDTO> GetTeachSemester(int teacherId)
        {
            SemesterDAO semesterDAO = new SemesterDAO(_context);
            return semesterDAO.GetTeachingSemester(teacherId).Select(semester => _mapper.Map<SemesterDTO>(semester)).ToList();
        }
    }
}
