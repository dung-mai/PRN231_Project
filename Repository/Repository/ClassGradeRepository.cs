using AutoMapper;
using BusinessObject.Models;
using Bussiness.DTO;
using DataAccess.DAO;
using DataAccess.Managers;
using DTO.Response.ClassGrade;
using DTO.Response.DetailScore;
using DTO.Response.GradeComponent;
using DTO.Response.StudyCourse;
using DTO.Response.SubjectResult;
using Repository.IRepository;

namespace Repository.Repository
{
    public class ClassGradeRepository : IClassGradeRepository
    {
        StudyCourseDAO _studyCourseDAO;
        SubjectResultDAO _subjectResultDAO;
        DetailScoreDAO _detailScoreDAO;
        GradeComponentDAO _gradeComponentDAO;
        IMapper _mapper;

        public ClassGradeRepository(FAPDbContext context, IMapper mapper)
        {
            _studyCourseDAO = new StudyCourseDAO(context);
            _subjectResultDAO = new SubjectResultDAO(context);
            _detailScoreDAO = new DetailScoreDAO(context);
            _gradeComponentDAO = new GradeComponentDAO(context);
            _mapper = mapper;
        }
        public ClassGradeDTO GetData(int classSubjectId, int gradeId)
        {
            List<StudyCourseResponseDTO> studyCourseResponseDTOs = _mapper.Map<List<StudyCourseResponseDTO>>(_studyCourseDAO.GetStudyCoursesBySubjectOfClassId(classSubjectId));
            List<SubjectResultResponseDTO> subjectResults = new List<SubjectResultResponseDTO>();
            foreach (var sc in studyCourseResponseDTOs)
            {
                SubjectResultResponseDTO subjectResultDTO = _mapper.Map<SubjectResultResponseDTO>(_subjectResultDAO.GetSubjectResultByStudyCourse((int)sc.Id));
                subjectResults.Add(subjectResultDTO);
            }

            ClassGradeDTO dto = new ClassGradeDTO();
            dto.SubjectOfClassId = classSubjectId;
            dto.GradeComponentId = gradeId;
            dto.GradeComponent = _mapper.Map<GradeComponentResponseDTO>(_gradeComponentDAO.GetGradeComponentById(gradeId));
            dto.Student = studyCourseResponseDTOs;
            dto.DetailScores = new List<DetailScoreResponseDTO>();
            foreach (var sr in subjectResults)
            {
                var detailscore = _mapper.Map<DetailScoreResponseDTO>(_detailScoreDAO.GetDetailScoreByGradeComponentIdSubjectResultId(gradeId,(int)sr.Id));
                if (detailscore != null)
                {
                    dto.DetailScores.Add(detailscore);
                }
            }
            return dto;
        }

        public List<AllClassGradeDTO> GetListClassAllSubjectResult(int classSubjectId)
        {
            List<StudyCourseResponseDTO> studyCourseResponseDTOs = _mapper.Map<List<StudyCourseResponseDTO>>(_studyCourseDAO.GetStudyCoursesBySubjectOfClassId(classSubjectId));
            List<SubjectResultResponseDTO> subjectResults = new List<SubjectResultResponseDTO>();
            foreach (var sc in studyCourseResponseDTOs)
            {
                SubjectResultResponseDTO subjectResultDTO = _mapper.Map<SubjectResultResponseDTO>(_subjectResultDAO.GetSubjectResultByStudyCourse((int)sc.Id));
                subjectResults.Add(subjectResultDTO);
            }

            List<AllClassGradeDTO> allClassGrades = new List<AllClassGradeDTO>();
            foreach (var subjectResult in subjectResults)
            {
                bool failFE = false;
                bool failFER = false;
                decimal totalScore = 0;
                AllClassGradeDTO allClassGradeDTO = new AllClassGradeDTO();
                allClassGradeDTO.SubjectOfClassId = classSubjectId;
                allClassGradeDTO.SubjectResult = subjectResult;
                allClassGradeDTO.DetailScores = _mapper.Map<List<DetailScoreResponseDTO>>(_detailScoreDAO.GetDetailScoreBySubjectResultId((int)subjectResult.Id));
                foreach (DetailScoreResponseDTO detailScore in allClassGradeDTO.DetailScores)
                {
                    GradeComponentResponseDTO gradeComponent = _mapper.Map<GradeComponentResponseDTO>(_gradeComponentDAO.GetGradeComponentById((int)detailScore.GradeComponentId));
                    if ((bool)gradeComponent.IsFinal && detailScore.Mark < gradeComponent.MinScore && gradeComponent.FinalScoreId == null)
                    {
                        allClassGradeDTO.status = false;
                        failFE = true;
                        break;
                    }
                    else if (detailScore.Mark <= gradeComponent.MinScore)
                    {
                        allClassGradeDTO.status = false;
                        break;
                    }
                    totalScore += (decimal)detailScore.Mark * ((decimal)gradeComponent.Weight / 100);
                }
                if (totalScore < 5 || failFE)
                {
                    totalScore = 0;
                    foreach (DetailScoreResponseDTO detailScore in allClassGradeDTO.DetailScores)
                    {
                        GradeComponentResponseDTO gradeComponent = _mapper.Map<GradeComponentResponseDTO>(_gradeComponentDAO.GetGradeComponentById((int)detailScore.GradeComponentId));
                        if (!(bool)gradeComponent.IsFinal)
                        {
                            if ((bool)gradeComponent.IsFinal && gradeComponent.FinalScoreId != null && detailScore.Mark < gradeComponent.MinScore)
                            {
                                allClassGradeDTO.status = false;
                                failFER = true;
                                break;
                            }
                            else if (detailScore.Mark <= gradeComponent.MinScore)
                            {
                                allClassGradeDTO.status = false;
                                break;
                            }
                            totalScore += (decimal)detailScore.Mark * ((decimal)gradeComponent.Weight / 100);
                        }
                    }
                }
                if (totalScore > 5)
                {
                    allClassGradeDTO.status = true;
                }
                if (failFER)
                {
                    allClassGradeDTO.status = false;
                }
                allClassGradeDTO.SubjectResult.AverageMark = (double)totalScore;
                allClassGrades.Add(allClassGradeDTO);
            }

            return allClassGrades;
        }
    }
}
