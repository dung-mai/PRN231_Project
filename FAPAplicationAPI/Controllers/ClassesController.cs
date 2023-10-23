using DTO.Request.Class;
using DTO.Response.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassesController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        // GET: api/Classs
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<ClassResponseDTO>> GetClasses()
        {
            return Ok(_classRepository.GetClasses());
        }

        //// GET: api/Classs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Class>> GetClass(int id)
        //{

        //    var class = await _context.Classs.FindAsync(id);

        //    if (class == null)
        //    {
        //        return NotFound();
        //    }

        //    return class;
        //}

        // PUT: api/Classs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutClass(int id, ClassUpdateDTO updateclass)
        {
            if (id != updateclass.Id)
            {
                return BadRequest();
            }

            if (_classRepository.UpdateClass(updateclass))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update Class");
            }
        }

        // POST: api/Classs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClass(ClassCreateDTO newclass)
        {
            if (_classRepository.SaveClass(newclass))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Class");
            }
        }

        // DELETE: api/Classs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            var deleteclass = _classRepository.GetClass(id);
            if (deleteclass == null)
            {
                return NotFound();
            }

            if (_classRepository.DeleteClass(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete Class");
            }
        }
    }
}
