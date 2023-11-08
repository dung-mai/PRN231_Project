using DTO.Request.Curricolum;
using DTO.Response.Curricolum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurricolumsController : ControllerBase
    {
        private readonly ICurricolumRepository _curricolumRepository;
        private readonly ISubjectCurricolumRepository _subjectCurricolumRepository;

        public CurricolumsController(ICurricolumRepository curricolumRepository, ISubjectCurricolumRepository subjectCurricolumRepository)
        {
            _curricolumRepository = curricolumRepository;
            _subjectCurricolumRepository = subjectCurricolumRepository;
        }

        // GET: api/Curricolums
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<CurricolumResponseDTO>> GetCurricolums()
        {
            return Ok(_curricolumRepository.GetCurricolums());
        }

        //// GET: api/Curricolums/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Curricolum>> GetCurricolum(int id)
        //{

        //    var curricolum = await _context.Curricolums.FindAsync(id);

        //    if (curricolum == null)
        //    {
        //        return NotFound();
        //    }

        //    return curricolum;
        //}

        // PUT: api/Curricolums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut("{id}")]
        public IActionResult PutCurricolum(int id, CurricolumUpdateDTO curricolum)
        {
            if (id != curricolum.Id)
            {
                return BadRequest();
            }
            foreach (var item in curricolum.Subjects)
            {
                item.CurricolumId = curricolum.Id;
                item.Status = true;
            }
            if (_curricolumRepository.UpdateCurricolum(curricolum))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update Curricolum");
            }
        }

        // POST: api/Curricolums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostCurricolum(CurricolumCreateDTO curricolum)
        {
            if (_curricolumRepository.SaveCurricolum(curricolum))
            {
                int insertedCurricolumId = _curricolumRepository.GetRecentlyAddCurricolum();
                foreach (var item in curricolum.Subjects)
                {
                    item.CurricolumId = insertedCurricolumId;
                    item.Status = true;
                }
                _subjectCurricolumRepository.SaveSubjectCurricolumRange(curricolum.Subjects);
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Curricolum");
            }
        }

        // DELETE: api/Curricolums/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCurricolum(int id)
        {
            var curricolum = _curricolumRepository.GetCurricolum(id);
            if (curricolum == null)
            {
                return NotFound();
            }

            if (_curricolumRepository.DeleteCurricolum(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete Curricolum");
            }
        }
    }
}
