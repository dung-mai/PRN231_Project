using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        FAPDbContext _context;
        public RoleDAO(FAPDbContext context)
        {
            _context = context;
        }


        public Role? GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(m => m.Roleid == id);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Boolean AddRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean DeleteRole(Role role)
        {
            try
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean UpdateRole(Role role)
        {
            try
            {
                Role? roleUpdate = GetRoleById(role.Roleid);
                if (roleUpdate != null)
                {
                    roleUpdate.RoleName = role.RoleName;
                    roleUpdate.UpdatedAt = role.UpdatedAt;
                    roleUpdate.UpdatedBy = role.UpdatedBy;
                    roleUpdate.IsDelete = role.IsDelete;
                    _context.Roles.Update(roleUpdate);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
