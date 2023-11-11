using DTO.Request.Class;
using DTO.Response.Class;
using DTO.Response.Student;
using DTO.Response.StudyCourse;
using DTO.Response.SubjectOfClass;
using FAPAplicationAPI.Utility;
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
        private readonly ISubjectOfClassRepository _subjectOfClassRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICurricolumRepository _curricolumRepository;
        private readonly ISemesterRepository _semesterRepository;
        private readonly ISubjectCurricolumRepository _subjectCurricolumRepository;
        private readonly IStudyCourseRepository _studyCourseRepository;

        public ClassesController(ISubjectOfClassRepository subjectOfClassRepository
           , IStudentRepository studentRepository, ICurricolumRepository curricolumRepository
           , IClassRepository classRepository, ISemesterRepository semesterRepository
           , ISubjectCurricolumRepository subjectCurricolumRepository
           , IStudyCourseRepository studyCourseRepository)
        {
            _subjectOfClassRepository = subjectOfClassRepository;
            _studentRepository = studentRepository;
            _curricolumRepository = curricolumRepository;
            _classRepository = classRepository;
            _semesterRepository = semesterRepository;
            _subjectCurricolumRepository = subjectCurricolumRepository;
            _studyCourseRepository = studyCourseRepository; 
        }

        // GET: api/Classs
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<ClassResponseDTO>> GetClasses()
        {
            return Ok(_classRepository.GetClassesAdd());
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

        [HttpGet]
        [Route("CreateClassOfSubject")]
        public IActionResult ResponseClassOfSubject(int semesterId, int curricolumnId)
        {
            int studentInClass = 2;
            var listStudent = _studentRepository.GetStudentsByCurricoulmnId(curricolumnId); ;
            double numberOfClass = listStudent.Count() / studentInClass;
            double remainder = listStudent.Count() % studentInClass;
            if (remainder > 0)
            {
                numberOfClass++;
            };
            var curricolumn = _curricolumRepository.GetCurricolum(curricolumnId);
            string className = $"{curricolumn.Major.MajorCode}{Common.GetAllAfterSecondUnderscore(curricolumn.CurricolumName)}";
            var listClass = _classRepository.AddClass((int)numberOfClass, className, semesterId);
            var semesterNow = _semesterRepository.GetSemesterById(semesterId);
            var semesterStart = _semesterRepository.GetSemesterById((int)curricolumn.StartSemeterId);
            var listSubjectOfCurricolumn = _subjectCurricolumRepository.GetSubjectCurricolumniByTermNo(semesterStart, semesterNow, curricolumnId);
            List<ClassReponseAddDTO> classReponseAddDTO = new List<ClassReponseAddDTO>();
            int start = 0;
            int end = 1;
            foreach (var cl in listClass)
            {

                List<StudyCourseResponseDTO> studyCourseResponseDTOs = new List<StudyCourseResponseDTO>();
                List<SubjectOfClassResponseDTO> subjectOfClassResponseDTO = new List<SubjectOfClassResponseDTO>();
                foreach (var s in listSubjectOfCurricolumn)
                {
                    if (end > listStudent.Count())
                    {
                        end = listStudent.Count();
                    }
                    for (int j = start; j < end; j++)
                    {
                        StudentResponseStudyCourseDTO student = new StudentResponseStudyCourseDTO()
                        {
                            Rollnumber = listStudent[j].Rollnumber,
                            AccountId = listStudent[j].AccountId,
                            FullName = listStudent[j].Account.Fullname,
                            Email = listStudent[j].Account.Email,
                        };
                        StudyCourseResponseDTO studentCourse = new StudyCourseResponseDTO()
                        {
                            Rollnumber = listStudent[j].Rollnumber,
                            RollnumberNavigation = student,
                        };
                        studyCourseResponseDTOs.Add(studentCourse);
                    }
                    start = end;
                    end++;
                    SubjectOfClassResponseDTO subjectOfClass = new SubjectOfClassResponseDTO()
                    {
                        ClassId = cl.Id,
                        SubjectId = s.Subject.Id,
                        SubjectName = s.Subject.SubjectName,
                        SubjectCode = s.Subject.SubjectCode,
                        StartDate = semesterNow.StartDate,
                        EndDate = semesterNow.EndDate,
                        UpdatedAt = DateTime.Now,
                        IsDelete = false,
                        StudyCourses = studyCourseResponseDTOs
                    };
                    subjectOfClassResponseDTO.Add(subjectOfClass);
                }
                ClassReponseAddDTO classReponse = new ClassReponseAddDTO()
                {
                    Id = cl.Id,
                    ClassName = cl.ClassName,
                    SemesterId = cl.SemesterId,
                    UpdatedAt = cl.UpdatedAt,
                    UpdatedBy = cl.UpdatedBy,
                    IsDelete = cl.IsDelete,
                    SubjectOfClasses = subjectOfClassResponseDTO,
                };
                classReponseAddDTO.Add(classReponse);
            }
            return Ok(classReponseAddDTO);
        }

        [HttpPost]
        [Route("CreateClassOfSubject")]
        public IActionResult CreateClassOfSubject(List<ClassReponseAddDTO> classReponseAddDTOs)
        {
            foreach (ClassReponseAddDTO newclass in classReponseAddDTOs)
            {
                if (!_classRepository.AddClassRes(newclass))
                {
                    return Conflict("Add Class Fail");
                }
                ClassResponseDTO classResponseDTO = _classRepository.GetClassLastIndex();
                foreach (SubjectOfClassResponseDTO subjectOfClass in newclass.SubjectOfClasses)
                {
                    subjectOfClass.ClassId = classResponseDTO.Id;
                    if (!_subjectOfClassRepository.SaveSubjectOfClassRes(subjectOfClass))
                    {
                        return Conflict("Add SubjectOfClass Fail");
                    }
                    SubjectOfClassResponseDTO subjectOfClassResponseDTO = _subjectOfClassRepository.GetSubjectOfClassLastIndex();
                    foreach (StudyCourseResponseDTO studyCourse in subjectOfClass.StudyCourses)
                    {
                        studyCourse.SubjectOfClassId = subjectOfClassResponseDTO.Id;
                        if (!_studyCourseRepository.SaveStudyCourseRes(studyCourse))
                        {
                            return Conflict("Add studyCourse Fail ");
                        }
                    }
                }
            }
            return Ok("Add successfully");
        }
    }
}
