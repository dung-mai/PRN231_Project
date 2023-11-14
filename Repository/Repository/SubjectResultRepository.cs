using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.SubjectResult;
using DTO.Response.StudyCourse;
using DTO.Response.SubjectResult;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SubjectResultRepository : ISubjectResultRepository
    {
        SubjectResultDAO subjectResultDAO;
        StudyCourseDAO studyCourseDAO;
        DetailScoreDAO detailScoreDAO;
        IMapper _mapper;

        public SubjectResultRepository(FAPDbContext context, IMapper mapper)
        {
            subjectResultDAO = new SubjectResultDAO(context);
            studyCourseDAO = new StudyCourseDAO(context);
            detailScoreDAO = new DetailScoreDAO(context);
            _mapper = mapper;
        }

        public bool AddSubjectResult(SubjectResultAddDTO subjectResult)
        {
            return subjectResultDAO.AddSubjectResult(_mapper.Map<SubjectResult>(subjectResult));
        }

        public void CreateResultOfClass(int subjectOfClassId)
        {
            List<StudyCourse> studyCourses = studyCourseDAO.GetStudyCourses().Where(sc => sc.SubjectOfClassId == subjectOfClassId).ToList();

            List<SubjectResult> subjectResults = new List<SubjectResult>();
            foreach (var item in studyCourses)
            {
                SubjectResult subjectResult = new SubjectResult
                {
                    IsDelete = false,
                    Status = 1,
                    StudyCourseId = item.Id,
                    TeacherId = item.SubjectOfClass.TeacherId,
                };
                subjectResults.Add(subjectResult);
            }
            subjectResultDAO.AddSubjectResultRange(subjectResults);

            subjectResults = subjectResultDAO.GetSubjectResults().Where(r => r.StudyCourse.SubjectOfClassId == subjectOfClassId).ToList();
            foreach (var item in subjectResults)
            {
                List<DetailScore> detailScores = new List<DetailScore>();
                foreach (var gradeItem in item.StudyCourse.SubjectOfClass.Subject.GradeComponents)
                {
                    DetailScore detailScore = new DetailScore
                    {
                        GradeComponentId = gradeItem.Id,
                        SubjectResultId = item.Id,
                        IsDelete = false
                    };
                    detailScores.Add(detailScore);
                }
                detailScoreDAO.AddDetailScoreRange(detailScores);
            }
        }

        public bool DeleteSubjectResult(int id)
        {
            return subjectResultDAO.DeleteSubjectResult(id);
        }

        public SubjectResultResponseDTO? GetSubjectResultById(int id)
        {
            return _mapper.Map<SubjectResultResponseDTO>(subjectResultDAO.GetSubjectResultById(id));
        }
        public List<SubjectResultResponseDTO> GetSubjectResults()
        {
            return _mapper.Map<List<SubjectResultResponseDTO>>(subjectResultDAO.GetSubjectResults());
        }

        public SubjectResultStudentResponseDTO? GetSubjectResultStudentById(int id)
        {
            return _mapper.Map<SubjectResultStudentResponseDTO>(subjectResultDAO.GetSubjectResultById(id));
        }

        public bool UpdateSubjectResult(SubjectResultUpdateDTO subjectResult)
        {
            return subjectResultDAO.UpdateSubjectResult(_mapper.Map<SubjectResult>(subjectResult));
        }

        public bool UpdateSubjectResultMark(SubjectResultResponseDTO subjectResult)
        {
            return subjectResultDAO.UpdateSubjectResultMark(_mapper.Map<SubjectResult>(subjectResult));
        }
    }
}
