using DTO.Request.SubjectResult;
using DTO.Response.SubjectResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectResultsController : ControllerBase
    {
        private readonly ISubjectResultRepository _subjectResultRepository;

        public SubjectResultsController(ISubjectResultRepository subjectResultRepository)
        {
            _subjectResultRepository = subjectResultRepository;
        }

        // GET: api/SubjectResult
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<SubjectResultResponseDTO>> GetSubjectResult()
        {
            return Ok(_subjectResultRepository.GetSubjectResults());
        }

        [HttpGet("{id}")]
        public IActionResult GetSubjectResult(int id)
        {
            return Ok(_subjectResultRepository.GetSubjectResultById(id));
        }


        [HttpPut("{id}")]
        public IActionResult PutSubjectResult(int id, SubjectResultUpdateDTO subjectResult)
        {
            if (id != subjectResult.Id)
            {
                return BadRequest();
            }

            _subjectResultRepository.UpdateSubjectResult(subjectResult);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateListSubjectResult")]
        public IActionResult PutSubjectResult(List<SubjectResultResponseDTO> subjectResult)
        {
            foreach (var subjectR in subjectResult)
            {
                _subjectResultRepository.UpdateSubjectResultMark(subjectR);
            }
            return NoContent();
        }

        // POST: api/SubjectResult
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSubjectResult(SubjectResultAddDTO subjectResult)
        {
            if (_subjectResultRepository.AddSubjectResult(subjectResult))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding SubjectResult");
            }
        }

        // DELETE: api/SubjectResult/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubjectResult(int id)
        {
            var subjectResult = _subjectResultRepository.GetSubjectResultById(id);
            if (subjectResult == null)
            {
                return NotFound();
            }

            _subjectResultRepository.DeleteSubjectResult(id);
            return NoContent();
        }

    }
}
