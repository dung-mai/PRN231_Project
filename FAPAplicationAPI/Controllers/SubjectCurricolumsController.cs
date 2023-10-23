using DTO.Request.SubjectCurricolum;
using DTO.Response.SubjectCurricolum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectCurricolumsController : ControllerBase
    {
        private readonly ISubjectCurricolumRepository _subjectCurricolumRepository;

        public SubjectCurricolumsController(ISubjectCurricolumRepository subjectCurricolumRepository)
        {
            _subjectCurricolumRepository = subjectCurricolumRepository;
        }

        // GET: api/SubjectCurricolums
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<SubjectCurricolumResponseDTO>> GetSubjectCurricolums()
        {
            return Ok(_subjectCurricolumRepository.GetSubjectCurricolums());
        }

        //// GET: api/SubjectCurricolums/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<SubjectCurricolum>> GetSubjectCurricolum(int id)
        //{

        //    var subjectCurricolum = await _context.SubjectCurricolums.FindAsync(id);

        //    if (subjectCurricolum == null)
        //    {
        //        return NotFound();
        //    }

        //    return subjectCurricolum;
        //}

        // PUT: api/SubjectCurricolums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutSubjectCurricolum(int id, SubjectCurricolumUpdateDTO subjectCurricolum)
        {
            if (id != subjectCurricolum.Id)
            {
                return BadRequest();
            }

            if (_subjectCurricolumRepository.UpdateSubjectCurricolum(subjectCurricolum))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update SubjectCurricolum");
            }
        }

        // POST: api/SubjectCurricolums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSubjectCurricolum(SubjectCurricolumCreateDTO subjectCurricolum)
        {
            if (_subjectCurricolumRepository.SaveSubjectCurricolum(subjectCurricolum))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding SubjectCurricolum");
            }
        }

        // DELETE: api/SubjectCurricolums/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubjectCurricolum(int id)
        {
            var subjectCurricolum = _subjectCurricolumRepository.GetSubjectCurricolum(id);
            if (subjectCurricolum == null)
            {
                return NotFound();
            }

            if (_subjectCurricolumRepository.DeleteSubjectCurricolum(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete SubjectCurricolum");
            }
        }
    }
}
