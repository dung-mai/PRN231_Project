using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.SubjectResult;
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
        IMapper _mapper;

        public SubjectResultRepository(FAPDbContext context, IMapper mapper)
        {
            subjectResultDAO = new SubjectResultDAO(context);
            _mapper = mapper;
        }

        public bool AddSubjectResult(SubjectResultAddDTO subjectResult)
        {
            return subjectResultDAO.AddSubjectResult(_mapper.Map<SubjectResult>(subjectResult));
        }

        public bool DeleteSubjectResult(SubjectResultUpdateDTO subjectResult)
        {
            return subjectResultDAO.DeleteSubjectResult(_mapper.Map<SubjectResult>(subjectResult));
        }

        public SubjectResultResponseDTO? GetSubjectResultById(int id)
        {
            return _mapper.Map<SubjectResultResponseDTO>(subjectResultDAO.GetSubjectResultById(id));
        }
        public List<SubjectResultResponseDTO> GetSubjectResults()
        {
            return _mapper.Map<List<SubjectResultResponseDTO>>(subjectResultDAO.GetSubjectResults());
        }

        public bool UpdateSubjectResult(SubjectResultUpdateDTO subjectResult)
        {
            return subjectResultDAO.UpdateSubjectResult(_mapper.Map<SubjectResult>(subjectResult));
        }
    }
}
