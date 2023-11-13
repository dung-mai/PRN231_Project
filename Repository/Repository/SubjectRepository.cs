using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Managers;
using DTO.Request.Subject;
using DTO.Response.Subject;
using Repository.IRepository;

namespace Repository.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public SubjectRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteSubject(int id)
        {
            try
            {
                SubjectDAO subjectDAO = new SubjectDAO(_context);
                subjectDAO.DeleteSubject(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetRecentlyAddSubject()
        {
            SubjectDAO subjectDAO = new SubjectDAO(_context);
            return subjectDAO.GetLastInsertSubject();
        }

        public SubjectResponseDTO? GetSubject(int id)
        {
            SubjectDAO subjectDAO = new SubjectDAO(_context);
            return _mapper.Map<SubjectResponseDTO>(subjectDAO.GetSubject(id));
        }

        public IQueryable<SubjectResponseDTO> GetSubjects()
        {
            SubjectDAO subjectDAO = new SubjectDAO(_context);
            List<Subject> subjects = subjectDAO.GetSubjects();
            return subjects.Select(s => _mapper.Map<SubjectResponseDTO>(s)).AsQueryable();
        }

        public bool SaveSubject(SubjectCreateDTO subject)
        {
            try
            {
                subject.GradeComponents = new List<DTO.Request.GradeComponent.GradeComponentAddDTO>();
                SubjectDAO subjectDAO = new SubjectDAO(_context);
                bool result = subjectDAO.AddSubject(_mapper.Map<Subject>(subject));
                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSubject(SubjectUpdateDTO subject)
        {
            try
            {
                SubjectDAO subjectDAO = new SubjectDAO(_context);
                bool result = subjectDAO.UpdateSubject(_mapper.Map<Subject>(subject));

                GradeComponentDAO gradeComponentDAO = new(_context);
                var oldGradeList = gradeComponentDAO.GetGradeComponentsBySubject(subject.Id);
                var newGradeList = subject.GradeComponents;
                if (oldGradeList.Count > 0)
                {
                    foreach (var oldGradeComponent in oldGradeList)
                    {
                        if (!oldGradeComponent.GradeItem.Equals("Final Exam Resit"))
                        {
                            var gradeComponent = newGradeList.FirstOrDefault(gc => gc.Id == oldGradeComponent.Id);
                            if (gradeComponent != null) //update change gradeComponent
                            {
                                gradeComponentDAO.UpdateGradeComponent(_mapper.Map<GradeComponent>(gradeComponent));
                            }
                            else //remove gradeComponent
                            {
                                gradeComponentDAO.DeleteGradeComponent(oldGradeComponent.Id);
                            }
                        }
                    }
                }
                if (newGradeList.Count > 0)
                {
                    foreach (var newGradeComponent in newGradeList)
                    {
                        if (newGradeComponent.Id == 0) //update change subject
                        {
                            if (!newGradeComponent.GradeItem.Equals("Final Exam Resit"))
                            {
                                gradeComponentDAO.AddGradeComponent(_mapper.Map<GradeComponent>(newGradeComponent));
                            }
                            else
                            {
                                var gradeComponent = oldGradeList.FirstOrDefault(gc => gc.GradeItem.Equals("Final Exam Resit"));
                                if (gradeComponent == null)
                                {
                                    gradeComponentDAO.AddGradeComponent(_mapper.Map<GradeComponent>(newGradeComponent));
                                }
                            }
                        }
                    }
                }

                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
