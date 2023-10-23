using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Role;
using DTO.Response.Role;
using Repository.IRepository;

namespace Repository.Repository
{
    public class RoleRepository : IRoleRepository
    {
        RoleDAO majorDAO;
        IMapper _mapper;

        public RoleRepository(FAPDbContext context, IMapper mapper)
        {
            majorDAO = new RoleDAO(context);
            _mapper = mapper;
        }

        public bool AddRole(RoleAddDTO major)
        {
            return majorDAO.AddRole(_mapper.Map<Role>(major));
        }

        public bool DeleteRole(int id)
        {
            return majorDAO.DeleteRole(id);
        }

        public RoleResponseDTO? GetRoleById(int id)
        {
            return _mapper.Map<RoleResponseDTO>(majorDAO.GetRoleById(id));
        }
        public List<RoleResponseDTO> GetRoles()
        {
            return _mapper.Map<List<RoleResponseDTO>>(majorDAO.GetRoles());
        }

        public bool UpdateRole(RoleUpdateDTO major)
        {
            return majorDAO.UpdateRole(_mapper.Map<Role>(major));
        }
    }
}
