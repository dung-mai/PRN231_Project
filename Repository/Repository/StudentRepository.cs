using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Managers;
using DTO.Request.Student;
using DTO.Response.Major;
using DTO.Response.Student;
using Repository.IRepository;

namespace Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentDAO studentDAO;
        MajorDAO majorDAO;
        IMapper _mapper;

        public StudentRepository(FAPDbContext context, IMapper mapper)
        {
            studentDAO = new StudentDAO(context);
            majorDAO = new MajorDAO(context);
            _mapper = mapper;
        }

        public bool AddStudent(StudentAddDTO student)
        {
            Student s = _mapper.Map<Student>(student);
            s.Account = null;
            return studentDAO.AddStudent(_mapper.Map<Student>(s));
        }

        public bool DeleteStudent(string roleNumber)
        {
            return studentDAO.DeleteStudent(roleNumber);
        }

        public string GetRoleNumber(string major, string course)
        {
            return studentDAO.GetRollNumber(major, course);
        }

        public StudentResponseDTO? GetStudentById(string roleNumber)
        {
            return _mapper.Map<StudentResponseDTO>(studentDAO.GetStudentById(roleNumber));
        }

        public StudentResponseDTO? GetStudentLastIndex()
        {
            return _mapper.Map<StudentResponseDTO>(studentDAO.GetStudentLastIndex());
        }

        public List<StudentResponseDTO> GetStudents()
        {
            return _mapper.Map<List<StudentResponseDTO>>(studentDAO.GetStudents());
        }

        public List<StudentResponseDTO> GetStudentsByCurricoulmnId(int curricoulmnId)
        {
            return _mapper.Map<List<StudentResponseDTO>>(studentDAO.GetStudentByCurricolumnId(curricoulmnId));
        }

        public bool UpdateStudent(StudentUpdateDTO student)
        {
            return studentDAO.UpdateStudent(_mapper.Map<Student>(student));
        }

        //public StudentDTO? GetStudentWithGradeResults(int accountId)
        //{
        //    StudentDAO manager = new StudentDAO(_context);
        //    Student? student = manager.GetStudentWithGradeResults(accountId);
        //    return student is null ? null : _mapper.Map<StudentDTO>(student);
        //}
     
    }
}
