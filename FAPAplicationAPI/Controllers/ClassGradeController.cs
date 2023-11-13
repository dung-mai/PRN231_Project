using DTO.Response.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;
using Repository.Repository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassGradeController : ControllerBase
    {
        private readonly IClassGradeRepository _classGradeRepository;

        public ClassGradeController(IClassGradeRepository classGradeRepository)
        {
            _classGradeRepository = classGradeRepository;
        }

        [HttpGet]
        public IActionResult GetClassSubject(int classSubjectId, int gradeId)
        {
            return Ok(_classGradeRepository.GetData(classSubjectId, gradeId));
        }

        [HttpGet]
        [Route("GetClassAllSubjectResult")]
        public IActionResult GetClassAllSubjectResult(int classSubjectId)
        {
            return Ok(_classGradeRepository.GetListClassAllSubjectResult(classSubjectId));
        }
    }
}
