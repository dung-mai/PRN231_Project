using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Managers;
using DTO.Request.Semester;
using DTO.Response.Semester;
using Repository.IRepository;

namespace Repository.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        SemesterDAO semesterDAO;
        IMapper _mapper;

        public SemesterRepository(FAPDbContext context, IMapper mapper)
        {
            semesterDAO = new SemesterDAO(context);
            _mapper = mapper;
        }

        public bool AddSemester(SemesterAddDTO semester)
        {
            return semesterDAO.AddSemester(_mapper.Map<Semester>(semester));
        }

        public bool DeleteSemester(SemesterUpdateDTO semester)
        {
            return semesterDAO.DeleteSemester(_mapper.Map<Semester>(semester));
        }

        public SemesterResponseDTO? GetSemesterById(int id)
        {
            return _mapper.Map<SemesterResponseDTO>(semesterDAO.GetSemesterById(id));
        }
        public List<SemesterResponseDTO> GetSemesters()
        {
            return _mapper.Map<List<SemesterResponseDTO>>(semesterDAO.GetSemesters());
        }

        public bool UpdateSemester(SemesterUpdateDTO semester)
        {
            return semesterDAO.UpdateSemester(_mapper.Map<Semester>(semester));
        }

        //public List<SemesterDTO> GetAllSemester()
        //{
        //    SemesterDAO semesterDAO = new SemesterDAO(_context);
        //    return semesterDAO.GetAllSemester().Select(semester => _mapper.Map<SemesterDTO>(semester)).ToList();
        //}

        //public SemesterDTO? GetCurrentSemester()
        //{
        //    SemesterDAO semesterDAO = new SemesterDAO(_context);
        //    Semester? semester = semesterDAO.GetCurrentSemester();
        //    return semester != null ? _mapper.Map<SemesterDTO>(semester) : null;
        //}

        //public List<SemesterDTO> GetTeachSemester(int teacherId)
        //{
        //    SemesterDAO semesterDAO = new SemesterDAO(_context);
        //    return semesterDAO.GetTeachingSemester(teacherId).Select(semester => _mapper.Map<SemesterDTO>(semester)).ToList();
        //}
    }
}
