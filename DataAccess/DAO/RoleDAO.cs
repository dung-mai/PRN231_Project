using BusinessObject.Models;
using System.Data;

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
            return _context.Roles.FirstOrDefault(r => r.Roleid == id && r.IsDelete == false);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.Where(r => r.IsDelete == false).ToList();
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

        public Boolean DeleteRole(int id)
        {
            try
            {
                Role? roleUpdate = GetRoleById(id);
                if (roleUpdate != null)
                {
                    roleUpdate.IsDelete = true;
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
