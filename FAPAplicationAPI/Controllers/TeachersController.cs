using DTO.Request.Teacher;
using DTO.Response.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // GET: api/Teacher
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<TeacherResponseDTO>> GetTeacher()
        {
            return Ok(_teacherRepository.GetTeachers());
        }


        [HttpPut("{id}")]
        public IActionResult PutTeacher(int id, TeacherUpdateDTO teacher)
        {
            if (id != teacher.AccountId)
            {
                return BadRequest();
            }

            _teacherRepository.UpdateTeacher(teacher);
            return NoContent();
        }

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTeacher(TeacherAddDTO teacher)
        {
            if (_teacherRepository.AddTeacher(teacher))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Teacher");
            }
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _teacherRepository.DeleteTeacher(id);
            return NoContent();
        }
    }
}
