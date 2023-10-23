using DTO.Request.StudyCourse;
using DTO.Response.StudyCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyCoursesController : ControllerBase
    {
        private readonly IStudyCourseRepository _studyCourseRepository;

        public StudyCoursesController(IStudyCourseRepository studyCourseRepository)
        {
            _studyCourseRepository = studyCourseRepository;
        }

        // GET: api/StudyCourses
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<StudyCourseResponseDTO>> GetStudyCourses()
        {
            return Ok(_studyCourseRepository.GetStudyCourses());
        }

        //// GET: api/StudyCourses/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<StudyCourse>> GetStudyCourse(int id)
        //{

        //    var studyCourse = await _context.StudyCourses.FindAsync(id);

        //    if (studyCourse == null)
        //    {
        //        return NotFound();
        //    }

        //    return studyCourse;
        //}

        // PUT: api/StudyCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutStudyCourse(int id, StudyCourseUpdateDTO studyCourse)
        {
            if (id != studyCourse.Id)
            {
                return BadRequest();
            }

            if (_studyCourseRepository.UpdateStudyCourse(studyCourse))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update StudyCourse");
            }
        }

        // POST: api/StudyCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStudyCourse(StudyCourseCreateDTO studyCourse)
        {
            if (_studyCourseRepository.SaveStudyCourse(studyCourse))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding StudyCourse");
            }
        }

        // DELETE: api/StudyCourses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudyCourse(int id)
        {
            var studyCourse = _studyCourseRepository.GetStudyCourse(id);
            if (studyCourse == null)
            {
                return NotFound();
            }

            if (_studyCourseRepository.DeleteStudyCourse(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete StudyCourse");
            }
        }
    }
}
