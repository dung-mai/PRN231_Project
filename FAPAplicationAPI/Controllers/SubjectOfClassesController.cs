using DTO.Request.SubjectOfClass;
using DTO.Response.SubjectOfClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectOfClassesController : ControllerBase
    {
        private readonly ISubjectOfClassRepository _subjectOfClassRepository;

        public SubjectOfClassesController(ISubjectOfClassRepository subjectOfClassRepository)
        {
            _subjectOfClassRepository = subjectOfClassRepository;
        }

        // GET: api/SubjectOfClasss
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<SubjectOfClassResponseDTO>> GetSubjectOfClasss()
        {
            return Ok(_subjectOfClassRepository.GetSubjectOfClasses());
        }

        //// GET: api/SubjectOfClasss/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<SubjectOfClass>> GetSubjectOfClass(int id)
        //{

        //    var subjectOfClass = await _context.SubjectOfClasss.FindAsync(id);

        //    if (subjectOfClass == null)
        //    {
        //        return NotFound();
        //    }

        //    return subjectOfClass;
        //}

        // PUT: api/SubjectOfClasss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutSubjectOfClass(int id, SubjectOfClassUpdateDTO subjectOfClass)
        {
            if (id != subjectOfClass.Id)
            {
                return BadRequest();
            }

            if (_subjectOfClassRepository.UpdateSubjectOfClass(subjectOfClass))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update SubjectOfClass");
            }
        }

        // POST: api/SubjectOfClasss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSubjectOfClass(SubjectOfClassCreateDTO subjectOfClass)
        {
            if (_subjectOfClassRepository.SaveSubjectOfClass(subjectOfClass))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding SubjectOfClass");
            }
        }

        // DELETE: api/SubjectOfClasss/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubjectOfClass(int id)
        {
            var subjectOfClass = _subjectOfClassRepository.GetSubjectOfClass(id);
            if (subjectOfClass == null)
            {
                return NotFound();
            }

            if (_subjectOfClassRepository.DeleteSubjectOfClass(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete SubjectOfClass");
            }
        }

        [HttpGet]
        [Route("GetByTeacherId")]
        public IActionResult GetBySubjectOfClassTeacherId(int teacherId)
        {
            var listSubjectOfClass = _subjectOfClassRepository.GetTeachingClass(teacherId);
            if(listSubjectOfClass == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(listSubjectOfClass);
            }
        }


    }
}
