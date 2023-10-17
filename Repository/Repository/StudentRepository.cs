using AutoMapper;
using BusinessObject.Models;
using DataAccess.Managers;
using Repository.IRepository;

namespace Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public StudentRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StudentDTO? GetStudentWithGradeResults(int accountId)
        {
            StudentDAO manager = new StudentDAO(_context);
            Student? student = manager.GetStudentWithGradeResults(accountId);
            return student is null ? null : _mapper.Map<StudentDTO>(student);
        }

    }
}
