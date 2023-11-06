using DTO.Request.Account;
using DTO.Request.Student;
using DTO.Response.Account;
using DTO.Response.Major;
using DTO.Response.Student;
using FAPAplicationAPI.Utility;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IMajorRepository _majorRepository;

        public StudentsController(IStudentRepository studentRepository, IAccountRepository accountRepository, IMajorRepository majorRepository)
        {
            _studentRepository = studentRepository;
            _accountRepository = accountRepository;
            _majorRepository = majorRepository;
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
            _accountRepository.UpdateAccountStudent(student.Account);
            _studentRepository.UpdateStudent(student);
            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStudent(StudentAddDTO student)
        {
            MajorResponseDTO major = _majorRepository.GetMajorById((int)student.MajorId);
            string rollnumber = _studentRepository.GetRoleNumber(major.StudentIdentityCode, student.AcademicYear);
            string[] middleName = student.Account.Middlename.Trim().Split(' ');
            string firstName = Common.RemoveDiacritics(student.Account.Firstname.ToLower());
            string lastname = Common.RemoveDiacritics(student.Account.Lastname.Substring(0, 1).ToLower());
            string middleCut = "";
            foreach (string s in middleName)
            {
                middleCut += Common.RemoveDiacritics(s.Substring(0, 1).ToLower());
            }
            student.Account.Email = $"{firstName}" +
                $"{lastname}" +
                $"{middleCut}" +
                $"{rollnumber.ToLower()}@fpt.edu.vn";
            student.Rollnumber = rollnumber;
            if (!_accountRepository.CreateAccountStudent(student.Account))
            {
                return Problem("Account information error");
            }
            AccountResponseDTO? accountResponseDTO = _accountRepository.GetAccountLastIndex();
            student.AccountId = accountResponseDTO?.Id;

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
            _accountRepository.DeleteAccount((int)student.AccountId);
            _studentRepository.DeleteStudent(rollnumber);
            return NoContent();
        }


    }
}
