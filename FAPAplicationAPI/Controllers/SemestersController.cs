using DTO.Request.Semester;
using DTO.Response.Semester;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController : ControllerBase
    {
        private readonly ISemesterRepository _semesterRepository;

        public SemestersController(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        // GET: api/Semester
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<SemesterResponseDTO>> GetSemester()
        {
            return Ok(_semesterRepository.GetSemesters());
        }


        [HttpPut("{id}")]
        public IActionResult PutSemester(int id, SemesterUpdateDTO semester)
        {
            if (id != semester.Id)
            {
                return BadRequest();
            }

            _semesterRepository.UpdateSemester(semester);
            return NoContent();
        }

        // POST: api/Semester
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSemester(SemesterAddDTO semester)
        {
            if (_semesterRepository.AddSemester(semester))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Semester");
            }
        }

        // DELETE: api/Semester/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSemester(int id)
        {
            var semester = _semesterRepository.GetSemesterById(id);
            if (semester == null)
            {
                return NotFound();
            }

            _semesterRepository.DeleteSemester(id);
            return NoContent();
        }
    }
}
