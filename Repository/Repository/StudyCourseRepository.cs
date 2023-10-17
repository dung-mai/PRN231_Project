using AutoMapper;
using BusinessObject.Models;
using Bussiness.DTO;
using DataAccess.DAO;
using Repository.IRepository;

namespace Repository.Repository
{
    public class StudyCourseRepository : IStudyCourseRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public StudyCourseRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StudyCourseDTO> GetStudyCourseByClass(int classId)
        {
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return studyCourseManager.GetStudyCourseByClass(classId)
                                        .Select(course => _mapper.Map<StudyCourseDTO>(course))
                                        .ToList();
        }

        public List<StudyCourseDTO> GetStudyCourseByStudent(int classId, string? rolenumber)
        {
            if (String.IsNullOrEmpty(rolenumber))
            {
                return GetStudyCourseByClass(classId);
            }
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return studyCourseManager.GetStudyCourseByStudent(classId, rolenumber)
                                        .Select(course => _mapper.Map<StudyCourseDTO>(course))
                                        .ToList();
        }

        public StudyCourseDTO? GetStudyCourseBySubject(int? semesterId, string rollnumber, int? courseId)
        {
            if(semesterId == null || courseId == null)
            {
                return null;
            }
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return _mapper.Map<StudyCourseDTO>(studyCourseManager.GetStudyCourseOfStudentBySubject((int)semesterId, rollnumber, (int)courseId));
        }

        public List<StudyCourseDTO> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber)
        {
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return studyCourseManager.GetStudyCourseOfStudentBySemester(semesterId, rollNumber)
                                        .Select(course => _mapper.Map<StudyCourseDTO>(course))
                                        .ToList();
        }

        public SubjectOfClassDTO? GetSubjectClassById(int classId)
        {
            SubjectOfClassDAO subjectOfClassManager = new SubjectOfClassDAO(_context);
            SubjectOfClass? subjectOfClass = subjectOfClassManager.GetSubjectClassById(classId);
            return subjectOfClass != null ? _mapper.Map<SubjectOfClassDTO>(subjectOfClass) : null;
        }
    }
}
