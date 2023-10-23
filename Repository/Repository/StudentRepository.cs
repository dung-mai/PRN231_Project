using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Managers;
using DTO.Request.Student;
using DTO.Response.Student;
using Repository.IRepository;

namespace Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentDAO studentDAO;
        IMapper _mapper;

        public StudentRepository(FAPDbContext context, IMapper mapper)
        {
            studentDAO = new StudentDAO(context);
            _mapper = mapper;
        }

        public bool AddStudent(StudentAddDTO student)
        {
            return studentDAO.AddStudent(_mapper.Map<Student>(student));
        }

        public bool DeleteStudent(string roleNumber)
        {
            return studentDAO.DeleteStudent(roleNumber);
        }

        public StudentResponseDTO? GetStudentById(string roleNumber)
        {
            return _mapper.Map<StudentResponseDTO>(studentDAO.GetStudentById(roleNumber));
        }
        public List<StudentResponseDTO> GetStudents()
        {
            return _mapper.Map<List<StudentResponseDTO>>(studentDAO.GetStudents());
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
