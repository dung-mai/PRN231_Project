using DTO.Request.Role;
using DTO.Response.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/Role
        [HttpGet]
        public ActionResult<IQueryable<RoleResponseDTO>> GetRole()
        {
            return Ok(_roleRepository.GetRoles());
        }


        [HttpPut("{id}")]
        public IActionResult PutRole(int id, RoleUpdateDTO role)
        {
            if (id != role.Roleid)
            {
                return BadRequest();
            }

            _roleRepository.UpdateRole(role);
            return NoContent();
        }

        // POST: api/Role
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostRole(RoleAddDTO role)
        {
            if (_roleRepository.AddRole(role))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Role");
            }
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleRepository.DeleteRole(id);
            return NoContent();
        }
    }
}
