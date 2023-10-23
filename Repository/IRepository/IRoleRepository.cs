using DTO.Request.Role;
using DTO.Response.Role;

namespace Repository.IRepository
{
    public interface IRoleRepository
    {
        bool AddRole(RoleAddDTO role);
        RoleResponseDTO? GetRoleById(int id);
        bool DeleteRole(int id);
        bool UpdateRole(RoleUpdateDTO role);
        List<RoleResponseDTO> GetRoles();
    }
}
