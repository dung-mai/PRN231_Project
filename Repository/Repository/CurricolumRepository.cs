using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Curricolum;
using DTO.Response.Curricolum;
using Repository.IRepository;
using System.ComponentModel.DataAnnotations;

namespace Repository.Repository
{
    public class CurricolumRepository : ICurricolumRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public CurricolumRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteCurricolum(int id)
        {
            try
            {
                CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
                curricolumDAO.DeleteCurricolum(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CurricolumResponseDTO? GetCurricolum(int id)
        {
            CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
            return _mapper.Map<CurricolumResponseDTO>(curricolumDAO.GetCurricolum(id));
        }

        public IQueryable<CurricolumResponseDTO> GetCurricolums()
        {
            CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
            List<Curricolum> curricolums = curricolumDAO.GetCurricolums();
            return curricolums.Select(c => _mapper.Map<CurricolumResponseDTO>(c)).AsQueryable();
        }

        public int GetRecentlyAddCurricolum()
        {
            CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
            return curricolumDAO.GetLastInsertCurricolum();
        }

        public bool SaveCurricolum(CurricolumCreateDTO curricolum)
        {
            try
            {
                CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
                bool result = curricolumDAO.AddCurricolum(_mapper.Map<Curricolum>(curricolum));
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
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCurricolum(CurricolumUpdateDTO curricolum)
        {
            try
            {
                CurricolumDAO curricolumDAO = new CurricolumDAO(_context);
                SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
                bool result = curricolumDAO.UpdateCurricolum(_mapper.Map<Curricolum>(curricolum));

                var oldSubjectList = subjectCurricolumDAO.GetSubjectCurricolumsById(curricolum.Id);
                var newSubjectList = curricolum.Subjects;
                if (oldSubjectList.Count > 0 && newSubjectList.Count > 0)
                {
                    foreach (var oldSubject in oldSubjectList)
                    {
                        var subject = newSubjectList.FirstOrDefault(s => s.Id == oldSubject.Id);
                        if (subject != null) //update change subject
                        {
                            subjectCurricolumDAO.UpdateSubjectCurricolum(_mapper.Map<SubjectCurricolum>(subject));
                        }
                        else //remove subject
                        {
                            subjectCurricolumDAO.DeleteSubjectCurricolum(oldSubject.Id);
                        }
                    }

                    foreach (var newSubject in newSubjectList)
                    {
                        if (newSubject.Id == 0) //update change subject
                        {
                            subjectCurricolumDAO.AddSubjectCurricolum(_mapper.Map<SubjectCurricolum>(newSubject));
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
