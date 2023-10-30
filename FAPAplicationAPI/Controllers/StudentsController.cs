using DTO.Request.Student;
using DTO.Response.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Student
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<StudentResponseDTO>> GetStudent()
        {
            return Ok(_studentRepository.GetStudents());
        }


        [HttpPut("{rollnumber}")]
        public IActionResult PutStudent(string rollnumber, StudentUpdateDTO student)
        {
            if (rollnumber != student.Rollnumber)
            {
                return BadRequest();
            }

            _studentRepository.UpdateStudent(student);
            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStudent(StudentAddDTO student)
        {
            if (_studentRepository.AddStudent(student))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Student");
            }
        }

        // DELETE: api/Student/5
        [HttpDelete("{rollnumber}")]
        public IActionResult DeleteStudent(string rollnumber)
        {
            var student = _studentRepository.GetStudentById(rollnumber);
            if (student == null)
            {
                return NotFound();
            }

            _studentRepository.DeleteStudent(rollnumber);
            return NoContent();
        }
    }
}
