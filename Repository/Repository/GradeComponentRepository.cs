using AutoMapper;
using BusinessObject.Models;
using Bussiness.DTO;
using DataAccess.DAO;
using DataAccess.Managers;
using DTO.Request.GradeComponent;
using DTO.Response.GradeComponent;
using Repository.IRepository;

namespace Repository.Repository
{
    public class GradeComponentRepository : IGradeComponentRepository
    {
        GradeComponentDAO gradeComponentDAO;
        IMapper _mapper;

        public GradeComponentRepository(FAPDbContext context, IMapper mapper)
        {
            gradeComponentDAO = new GradeComponentDAO(context);
            _mapper = mapper;
        }

        public bool AddGradeComponent(GradeComponentAddDTO gradeComponent)
        {
            return gradeComponentDAO.AddGradeComponent(_mapper.Map<GradeComponent>(gradeComponent));
        }

        public bool DeleteGradeComponent(int id)
        {
            return gradeComponentDAO.DeleteGradeComponent(id);
        }

        public GradeComponentResponseDTO? GetGradeComponentById(int id)
        {
            return _mapper.Map<GradeComponentResponseDTO>(gradeComponentDAO.GetGradeComponentById(id));
        }
        public List<GradeComponentResponseDTO> GetGradeComponents()
        {
            return _mapper.Map<List<GradeComponentResponseDTO>>(gradeComponentDAO.GetGradeComponents());
        }

        public bool UpdateGradeComponent(GradeComponentUpdateDTO gradeComponent)
        {
            return gradeComponentDAO.UpdateGradeComponent(_mapper.Map<GradeComponent>(gradeComponent));
        }

        private DetailScoreDTO? FindScoreOfGradeComponent(int componentId, List<DetailScore> detailScores)
        {
            DetailScore? detailScore = detailScores.FirstOrDefault(score => score.GradeComponentId == componentId);
            return detailScore == null ? null : _mapper.Map<DetailScoreDTO>(detailScore);
        }

        //

        //public GradeComponentDTO GetComponentById(int? item)
        //{
        //    GradeComponentManager gradeComponentManager = new GradeComponentManager(_context);
        //    GradeComponentDTO? gradeComponent = gradeComponentManager.GetComponentById(score => score.GradeComponentId == componentId);
        //    return detailScore == null ? null : _mapper.Map<DetailScoreDTO>(detailScore);
        //}
        //


        List<GradeComponentResponseDTO> IGradeComponentRepository.GetGradeComponentsOfSubjet(int classId)
        {
            //GradeComponentDAO gradeComponentManager = new GradeComponentManager(_context);
            //SubjectOfClassManager subjectOfClassManager = new SubjectOfClassManager(_context);
            //SubjectOfClass? subjectOfClass = subjectOfClassManager.GetSubjectClassById(classId);
            //if(subjectOfClass == null)
            //{
            //    return new List<GradeComponentDTO>();
            //}

            //List<GradeComponent> components = gradeComponentManager.GetGradeComponentsOfSubject((int) subjectOfClass.SubjectId);
            //return components.Select(c => _mapper.Map<GradeComponentDTO>(c)).ToList();
            throw new NotImplementedException();
        }


        List<GradeComponentResponseDTO> IGradeComponentRepository.GetGradeComponentsOfSubjetWithStudentResult(int? subjectId, int studyCourseId)
        {
            //if (subjectId == null)
            //{
            //    return new List<GradeComponentDTO>();
            //}
            //GradeComponentDAO gradeComponentManager = new GradeComponentManager(_context);
            //DetailScoreManager detailScoreManager = new DetailScoreManager(_context);
            //List<DetailScore> detailScores = detailScoreManager.GetScoresByStudyResult(studyCourseId);

            //List<GradeComponent> components = gradeComponentManager.GetGradeComponentsOfSubject((int)subjectId);
            //List<GradeComponentDTO> componentDTOs = components.Select(c => _mapper.Map<GradeComponentDTO>(c)).ToList();
            //return componentDTOs.Select(component =>
            //                        {
            //                            component.DetailScore = FindScoreOfGradeComponent(component.Id, detailScores);
            //                            return component;
            //                        })
            //                    .ToList();
            throw new NotImplementedException();
        }

    }
}
