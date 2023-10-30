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
        RoleDAO roleDAO;
        IMapper _mapper;

        public RoleRepository(FAPDbContext context, IMapper mapper)
        {
            roleDAO = new RoleDAO(context);
            _mapper = mapper;
        }

        public bool AddRole(RoleAddDTO role)
        {
            return roleDAO.AddRole(_mapper.Map<Role>(role));
        }

        public bool DeleteRole(int id)
        {
            return roleDAO.DeleteRole(id);
        }

        public RoleResponseDTO? GetRoleById(int id)
        {
            return _mapper.Map<RoleResponseDTO>(roleDAO.GetRoleById(id));
        }
        public List<RoleResponseDTO> GetRoles()
        {
            return _mapper.Map<List<RoleResponseDTO>>(roleDAO.GetRoles());
        }

        public bool UpdateRole(RoleUpdateDTO role)
        {
            return roleDAO.UpdateRole(_mapper.Map<Role>(role));
        }
    }
}
