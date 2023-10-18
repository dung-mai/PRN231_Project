using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Subject;
using DTO.Response.Subject;
using Repository.IRepository;

namespace Repository.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public SubjectRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteSubject(int id)
        {
            try
            {
                SubjectDAO subjectDAO = new SubjectDAO(_context);
                subjectDAO.DeleteSubject(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SubjectResponseDTO? GetSubject(int id)
        {
                SubjectDAO subjectDAO = new SubjectDAO(_context);
            return _mapper.Map<SubjectResponseDTO>(subjectDAO.GetSubject(id));
        }

        public IQueryable<SubjectResponseDTO> GetSubjects()
        {
            SubjectDAO subjectDAO = new SubjectDAO(_context);
            List<Subject> subjects = subjectDAO.GetSubjects();
            return subjects.Select(s => _mapper.Map<SubjectResponseDTO>(s)).AsQueryable();
        }

        public bool SaveSubject(SubjectCreateDTO subject)
        {
            try
            {
                SubjectDAO subjectDAO = new SubjectDAO(_context);
                int result = subjectDAO.AddSubject(_mapper.Map<Subject>(subject));
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

        public void UpdateSubject(SubjectUpdateDTO subject)
        {
            SubjectDAO subjectDAO = new(_context);
            subjectDAO.UpdateSubject(_mapper.Map<Subject>(subject));
            _context.SaveChanges();
        }
    }
}
