using AutoMapper;
using BusinessObject.Models;
using Bussiness.DTO;
using DataAccess.DAO;
using DTO.Request.StudyCourse;
using DTO.Response.StudyCourse;
using DTO.Response.SubjectOfClass;
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

        public List<StudyCourseResponseDTO> GetStudyCourseByClass(int classId)
        {
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return studyCourseManager.GetStudyCourseByClass(classId)
                                        .Select(course => _mapper.Map<StudyCourseResponseDTO>(course))
                                        .ToList();
        }

        public List<StudyCourseResponseDTO> GetStudyCourseByStudent(int classId, string? rolenumber)
        {
            if (String.IsNullOrEmpty(rolenumber))
            {
                return GetStudyCourseByClass(classId);
            }
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return studyCourseManager.GetStudyCourseByStudent(classId, rolenumber)
                                        .Select(course => _mapper.Map<StudyCourseResponseDTO>(course))
                                        .ToList();
        }

        public StudyCourseResponseDTO? GetStudyCourseBySubject(int? semesterId, string rollnumber, int? courseId)
        {
            if(semesterId == null || courseId == null)
            {
                return null;
            }
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return _mapper.Map<StudyCourseResponseDTO>(studyCourseManager.GetStudyCourseOfStudentBySubject((int)semesterId, rollnumber, (int)courseId));
        }

        public List<StudyCourseResponseDTO> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber)
        {
            StudyCourseDAO studyCourseManager = new StudyCourseDAO(_context);
            return studyCourseManager.GetStudyCourseOfStudentBySemester(semesterId, rollNumber)
                                        .Select(course => _mapper.Map<StudyCourseResponseDTO>(course))
                                        .ToList();
        }

        //public SubjectOfClassDTO? GetSubjectClassById(int classId)
        //{
        //    SubjectOfClassDAO subjectOfClassManager = new SubjectOfClassDAO(_context);
        //    SubjectOfClass? subjectOfClass = subjectOfClassManager.GetSubjectClassById(classId);
        //    return subjectOfClass != null ? _mapper.Map<SubjectOfClassDTO>(subjectOfClass) : null;
        //}

        public bool DeleteStudyCourse(int id)
        {
            try
            {
                StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
                studyCourseDAO.DeleteStudyCourse(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public StudyCourseResponseDTO? GetStudyCourse(int id)
        {
            StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
            return _mapper.Map<StudyCourseResponseDTO>(studyCourseDAO.GetStudyCourse(id));
        }

        public IQueryable<StudyCourseResponseDTO> GetStudyCourses()
        {
            StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
            List<StudyCourse> studyCourses = studyCourseDAO.GetStudyCourses();
            return studyCourses.Select(sc => _mapper.Map<StudyCourseResponseDTO>(sc)).AsQueryable();
        }

        public bool SaveStudyCourse(StudyCourseCreateDTO studyCourse)
        {
            try
            {
                StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
                bool result = studyCourseDAO.AddStudyCourse(_mapper.Map<StudyCourse>(studyCourse));
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

        public bool UpdateStudyCourse(StudyCourseUpdateDTO studyCourse)
        {
            try
            {
                StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
                bool result = studyCourseDAO.UpdateStudyCourse(_mapper.Map<StudyCourse>(studyCourse));
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

        public bool SaveStudyCourseRes(StudyCourseResponseDTO studyCourse)
        {
            try
            {
                StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
                bool result = studyCourseDAO.AddStudyCourse(_mapper.Map<StudyCourse>(studyCourse));
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

        public List<StudyCourseResponseAllDTO> GetStudyCourseByStudentRollnumber(string rolenumber)
        {
            StudyCourseDAO studyCourseDAO = new StudyCourseDAO(_context);
            return _mapper.Map<List<StudyCourseResponseAllDTO>>(studyCourseDAO.GetStudyCourseByStudentRollnumber(rolenumber));
        }
    }
}
