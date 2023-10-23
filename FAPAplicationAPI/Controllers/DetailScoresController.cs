using DTO.Request.DetailScore;
using DTO.Response.DetailScore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailScoresController : ControllerBase
    {
        private readonly IDetailScoreRepository _detailScoreRepository;

        public DetailScoresController(IDetailScoreRepository detailScoreRepository)
        {
            _detailScoreRepository = detailScoreRepository;
        }

        // GET: api/DetailScore
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<DetailScoreResponseDTO>> GetDetailScore()
        {
            return Ok(_detailScoreRepository.GetDetailScores());
        }


        [HttpPut("{id}")]
        public IActionResult PutDetailScore(int id, DetailScoreUpdateDTO detailScore)
        {
            if (id != detailScore.Id)
            {
                return BadRequest();
            }

            _detailScoreRepository.UpdateDetailScore(detailScore);
            return NoContent();
        }

        // POST: api/DetailScore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDetailScore(DetailScoreAddDTO detailScore)
        {
            if (_detailScoreRepository.AddDetailScore(detailScore))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding DetailScore");
            }
        }

        // DELETE: api/DetailScore/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDetailScore(int id)
        {
            var detailScore = _detailScoreRepository.GetDetailScoreById(id);
            if (detailScore == null)
            {
                return NotFound();
            }

            _detailScoreRepository.DeleteDetailScore(id);
            return NoContent();
        }
    }
}
