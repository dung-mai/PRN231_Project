using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Major;
using DTO.Response.Major;
using Repository.IRepository;

namespace Repository.Repository
{
    public class MajorRepository : IMajorRepository
    {
        MajorDAO majorDAO;
        IMapper _mapper;

        public MajorRepository(FAPDbContext context, IMapper mapper)
        {
            majorDAO = new MajorDAO(context);
            _mapper = mapper;
        }

        public bool AddMajor(MajorAddDTO major)
        {
            return majorDAO.AddMajor(_mapper.Map<Major>(major));
        }

        public bool DeleteMajor(MajorUpdateDTO major)
        {
            return majorDAO.DeleteMajor(_mapper.Map<Major>(major));
        }

        public MajorResponseDTO? GetMajorById(int id)
        {
            return _mapper.Map<MajorResponseDTO>(majorDAO.GetMajorById(id));
        }
        public List<MajorResponseDTO> GetMajors()
        {
            return _mapper.Map<List<MajorResponseDTO>>(majorDAO.GetMajors());
        }

        public bool UpdateMajor(MajorUpdateDTO major)
        {
            return majorDAO.UpdateMajor(_mapper.Map<Major>(major));
        }
    }
}
