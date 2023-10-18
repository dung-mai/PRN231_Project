using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Curricolum;
using DTO.Response.Curricolum;
using Repository.IRepository;

namespace Repository.Repository
{
    public class CurricolumRepository : ICurricolumRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public CurricolumRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteCurricolum(int id)
        {
            try
            {
                CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
                curricolumDAO.DeleteCurricolum(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CurricolumResponseDTO? GetCurricolum(int id)
        {
            CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
            return _mapper.Map<CurricolumResponseDTO>(curricolumDAO.GetCurricolum(id));
        }

        public IQueryable<CurricolumResponseDTO> GetCurricolums()
        {
            CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
            List<Curricolum> curricolums = curricolumDAO.GetCurricolums();
            return curricolums.Select(c => _mapper.Map<CurricolumResponseDTO>(c)).AsQueryable();
        }

        public bool SaveCurricolum(CurricolumCreateDTO curricolum)
        {
            try
            {
                CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
                int result = curricolumDAO.AddCurricolum(_mapper.Map<Curricolum>(curricolum));
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

        public void UpdateCurricolum(CurricolumUpdateDTO curricolum)
        {
            CurricolumDAO curricolumDAO = new(_context);
            curricolumDAO.UpdateCurricolum(_mapper.Map<Curricolum>(curricolum));
            _context.SaveChanges();
        }
    }
}
