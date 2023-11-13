using BusinessObject.Models;
using DTO.Request.GradeComponent;
using DTO.Request.Subject;
using DTO.Response.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;
using Repository.Repository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IGradeComponentRepository _gradeComponentRepository;

        public SubjectsController(ISubjectRepository subjectRepository, IGradeComponentRepository gradeComponentRepository)
        {
            _subjectRepository = subjectRepository;
            _gradeComponentRepository = gradeComponentRepository;
        }

        // GET: api/Subjects
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<SubjectResponseDTO>> GetSubjects()
        {
            return Ok(_subjectRepository.GetSubjects());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IQueryable<SubjectResponseDTO>> GetSubjects(int id)
        {
            return Ok(_subjectRepository.GetSubject(id));
        }

        //// GET: api/Subjects/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Subject>> GetSubject(int id)
        //{

        //    var subject = await _context.Subjects.FindAsync(id);

        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return subject;
        //}

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutSubject(int id, SubjectUpdateDTO subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }
            GradeComponentUpdateDTO? finalExam = subject.GradeComponents.FirstOrDefault(gc => gc?.GradeCategory?.ToLower() == "final exam");
            if (finalExam == null)
            {
                subject.GradeComponents.Add(new DTO.Request.GradeComponent.GradeComponentUpdateDTO
                {
                    GradeCategory = "Final Exam",
                    GradeItem = "Final Exam",
                    Weight = 0
                });
            }
            subject.GradeComponents.Add(new DTO.Request.GradeComponent.GradeComponentUpdateDTO
            {
                GradeCategory = "Final Exam Resit",
                GradeItem = "Final Exam Resit",
                Weight = finalExam?.Weight
            });

            foreach (var item in subject.GradeComponents)
            {
                item.SubjectId = subject.Id;
                item.MinScore = 0;
                item.IsFinal = item?.GradeCategory?.ToLower() == "final exam";
            }

            if (_subjectRepository.UpdateSubject(subject))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Update Subject");
            }
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSubject(SubjectCreateDTO subject)
        {
            List<GradeComponentAddDTO> gradeComponentAdds = subject.GradeComponents;
            if (_subjectRepository.SaveSubject(subject))
            {
                int insertedSubjectId = _subjectRepository.GetRecentlyAddSubject();

                GradeComponentAddDTO? finalExam = gradeComponentAdds.FirstOrDefault(gc => gc?.GradeCategory?.ToLower() == "final exam");
                if (finalExam == null)
                {
                    gradeComponentAdds.Add(new DTO.Request.GradeComponent.GradeComponentAddDTO
                    {
                        GradeCategory = "Final Exam",
                        GradeItem = "Final Exam",
                        Weight = 0
                    });
                }
                gradeComponentAdds.Add(new DTO.Request.GradeComponent.GradeComponentAddDTO
                {
                    GradeCategory = "Final Exam Resit",
                    GradeItem = "Final Exam Resit",
                    Weight = finalExam?.Weight
                });

                foreach (var item in gradeComponentAdds)
                {
                    item.SubjectId = insertedSubjectId;
                    item.MinScore = 0;
                    item.IsFinal = item?.GradeCategory?.ToLower() == "final exam";
                }
                _gradeComponentRepository.SaveGradeComponentRange(gradeComponentAdds);
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Subject");
            }
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _subjectRepository.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }

            if (_subjectRepository.DeleteSubject(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Delete Subject");
            }
        }
    }
}
