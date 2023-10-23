using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Teacher;
using DTO.Response.Teacher;
using Repository.IRepository;

namespace Repository.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        TeacherDAO teacherDAO;
        IMapper _mapper;

        public TeacherRepository(FAPDbContext context, IMapper mapper)
        {
            teacherDAO = new TeacherDAO(context);
            _mapper = mapper;
        }

        public bool AddTeacher(TeacherAddDTO teacher)
        {
            return teacherDAO.AddTeacher(_mapper.Map<Teacher>(teacher));
        }

        public bool DeleteTeacher(TeacherUpdateDTO teacher)
        {
            return teacherDAO.DeleteTeacher(_mapper.Map<Teacher>(teacher));
        }

        public TeacherResponseDTO? GetTeacherById(int id)
        {
            return _mapper.Map<TeacherResponseDTO>(teacherDAO.GetTeacherById(id));
        }
        public List<TeacherResponseDTO> GetTeachers()
        {
            return _mapper.Map<List<TeacherResponseDTO>>(teacherDAO.GetTeachers());
        }

        public bool UpdateTeacher(TeacherUpdateDTO teacher)
        {
            return teacherDAO.UpdateTeacher(_mapper.Map<Teacher>(teacher));
        }
    }
}
