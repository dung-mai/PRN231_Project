using AutoMapper;
using BusinessObject.Models;
using DataAccess.Managers;
using Repository.IRepository;

namespace Repository.Repository
{
    public class GradeComponentRepository : IGradeComponentRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public GradeComponentRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public GradeComponentDTO GetComponentById(int? item)
        //{
        //    GradeComponentManager gradeComponentManager = new GradeComponentManager(_context);
        //    GradeComponentDTO? gradeComponent = gradeComponentManager.GetComponentById(score => score.GradeComponentId == componentId);
        //    return detailScore == null ? null : _mapper.Map<DetailScoreDTO>(detailScore);
        //}

        public List<GradeComponentDTO> GetGradeComponentsOfSubjet(int classId)
        {
            GradeComponentDAO gradeComponentManager = new GradeComponentManager(_context);
            SubjectOfClassManager subjectOfClassManager = new SubjectOfClassManager(_context);
            SubjectOfClass? subjectOfClass = subjectOfClassManager.GetSubjectClassById(classId);
            if(subjectOfClass == null)
            {
                return new List<GradeComponentDTO>();
            }

            List<GradeComponent> components = gradeComponentManager.GetGradeComponentsOfSubject((int) subjectOfClass.SubjectId);
            return components.Select(c => _mapper.Map<GradeComponentDTO>(c)).ToList();
        }

        public List<GradeComponentDTO> GetGradeComponentsOfSubjetWithStudentResult(int? subjectId, int studyCourseId)
        {
            if (subjectId == null)
            {
                return new List<GradeComponentDTO>();
            }
            GradeComponentDAO gradeComponentManager = new GradeComponentManager(_context);
            DetailScoreManager detailScoreManager = new DetailScoreManager(_context);
            List<DetailScore> detailScores = detailScoreManager.GetScoresByStudyResult(studyCourseId);

            List<GradeComponent> components = gradeComponentManager.GetGradeComponentsOfSubject((int)subjectId);
            List<GradeComponentDTO> componentDTOs = components.Select(c => _mapper.Map<GradeComponentDTO>(c)).ToList();
            return componentDTOs.Select(component =>
                                    {
                                        component.DetailScore = FindScoreOfGradeComponent(component.Id, detailScores);
                                        return component;
                                    })
                                .ToList();
        }

        private DetailScoreDTO? FindScoreOfGradeComponent(int componentId, List<DetailScore> detailScores)
        {
            DetailScore? detailScore = detailScores.FirstOrDefault(score => score.GradeComponentId == componentId);
            return detailScore == null ? null : _mapper.Map<DetailScoreDTO>(detailScore);
        }
    }
}
