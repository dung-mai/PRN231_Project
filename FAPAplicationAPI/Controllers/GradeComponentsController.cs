using DTO.Request.GradeComponent;
using DTO.Response.GradeComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeComponentsController : ControllerBase
    {
        private readonly IGradeComponentRepository _gradeComponentRepository;

        public GradeComponentsController(IGradeComponentRepository gradeComponentRepository)
        {
            _gradeComponentRepository = gradeComponentRepository;
        }

        // GET: api/GradeComponent
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<GradeComponentResponseDTO>> GetGradeComponent()
        {
            return Ok(_gradeComponentRepository.GetGradeComponents());
        }


        [HttpPut("{id}")]
        public IActionResult PutGradeComponent(int id, GradeComponentUpdateDTO gradeComponent)
        {
            if (id != gradeComponent.Id)
            {
                return BadRequest();
            }

            _gradeComponentRepository.UpdateGradeComponent(gradeComponent);
            return NoContent();
        }

        // POST: api/GradeComponent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostGradeComponent(GradeComponentAddDTO gradeComponent)
        {
            if (_gradeComponentRepository.AddGradeComponent(gradeComponent))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding GradeComponent");
            }
        }

        // DELETE: api/GradeComponent/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGradeComponent(int id)
        {
            var gradeComponent = _gradeComponentRepository.GetGradeComponentById(id);
            if (gradeComponent == null)
            {
                return NotFound();
            }

            _gradeComponentRepository.DeleteGradeComponent(id);
            return NoContent();
        }
    }
}
