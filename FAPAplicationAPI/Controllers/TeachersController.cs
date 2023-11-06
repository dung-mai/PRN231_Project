using BusinessObject.Models;
using DTO.Request.Teacher;
using DTO.Response.Account;
using DTO.Response.Teacher;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;
using Repository.Repository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAccountRepository _accountRepository;

        public TeachersController(ITeacherRepository teacherRepository, IAccountRepository accountRepository)
        {
            _teacherRepository = teacherRepository;
            _accountRepository = accountRepository;
        }

        // GET: api/Teacher
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<TeacherResponseDTO>> GetTeacher()
        {
            return Ok(_teacherRepository.GetTeachers());
        }


        [HttpPut("{id}")]
        public IActionResult PutTeacher(int id, TeacherUpdateDTO teacher)
        {
            if (id != teacher.AccountId)
            {
                return BadRequest();
            }
            _accountRepository.UpdateAccountTeacher(teacher.Account);
            _teacherRepository.UpdateTeacher(teacher);
            return NoContent();
        }

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTeacher(TeacherAddDTO teacher)
        {
            string[] middleName = teacher.Account.Middlename.Trim().Split(' ');
            string firstName = Common.RemoveDiacritics(teacher.Account.Firstname.ToLower());
            string lastname = Common.RemoveDiacritics(teacher.Account.Lastname.Substring(0, 1).ToLower());
            string middleCut = "";
            foreach (string s in middleName)
            {
                middleCut += Common.RemoveDiacritics(s.Substring(0, 1).ToLower());
            }
            string teacherCode = _teacherRepository.GetTeacherCode(Common.RemoveDiacritics($"{firstName}{lastname}{middleCut}"));
            teacher.Account.Email = $"{teacherCode}@fpt.edu.vn";
            teacher.TeacherCode = teacherCode;
            if (!_accountRepository.CreateAccountTeacher(teacher.Account))
            {
                return Problem("Account information error");
            }
            AccountResponseDTO accountResponseDTO = _accountRepository.GetAccountLastIndex();
            teacher.AccountId = accountResponseDTO.Id;
            if (_teacherRepository.AddTeacher(teacher))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Teacher");
            }
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _teacherRepository.DeleteTeacher(id);
            return NoContent();
        }
    }
}
