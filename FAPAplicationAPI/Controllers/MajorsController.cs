using DTO.Request.Major;
using DTO.Response.Major;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorRepository _majorRepository;

        public MajorsController(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }

        // GET: api/Major
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<MajorResponseDTO>> GetMajor()
        {
            return Ok(_majorRepository.GetMajors());
        }


        [HttpPut("{id}")]
        public IActionResult PutMajor(int id, MajorUpdateDTO major)
        {
            if (id != major.Id)
            {
                return BadRequest();
            }

            _majorRepository.UpdateMajor(major);
            return NoContent();
        }

        // POST: api/Major
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostMajor(MajorAddDTO major)
        {
            if (_majorRepository.AddMajor(major))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Major");
            }
        }

        // DELETE: api/Major/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMajor(int id)
        {
            var major = _majorRepository.GetMajorById(id);
            if (major == null)
            {
                return NotFound();
            }

            _majorRepository.DeleteMajor(id);
            return NoContent();
        }
    }
}
