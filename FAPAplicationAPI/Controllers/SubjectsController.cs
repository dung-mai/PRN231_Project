using DTO.Request.Subject;
using DTO.Response.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        // GET: api/Subjects
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<SubjectResponseDTO>> GetSubjects()
        {
            return Ok(_subjectRepository.GetSubjects());
        }

        //// GET: api/Subjects/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Subject>> GetSubject(int id)
        //{

        //    var subject = await _context.Subjects.FindAsync(id);

        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return subject;
        //}

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutSubject(int id, SubjectUpdateDTO subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            if (_subjectRepository.UpdateSubject(subject))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update Subject");
            }
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSubject(SubjectCreateDTO subject)
        {
            if (_subjectRepository.SaveSubject(subject))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Subject");
            }
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _subjectRepository.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }

            if (_subjectRepository.DeleteSubject(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete Subject");
            }
        }
    }
}
