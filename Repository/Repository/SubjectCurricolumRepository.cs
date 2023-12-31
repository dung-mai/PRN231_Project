﻿using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.SubjectCurricolum;
using DTO.Response.Semester;
using DTO.Response.SubjectCurricolum;
using Repository.IRepository;

namespace Repository.Repository
{
    public class SubjectCurricolumRepository : ISubjectCurricolumRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public SubjectCurricolumRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteSubjectCurricolum(int id)
        {
            try
            {
                SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
                subjectCurricolumDAO.DeleteSubjectCurricolum(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SubjectCurricolumResponseDTO? GetSubjectCurricolum(int id)
        {
            SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
            return _mapper.Map<SubjectCurricolumResponseDTO>(subjectCurricolumDAO.GetSubjectCurricolum(id));
        }

        public List<SubjectCurricolumResponseDTO> GetSubjectCurricolumniByTermNo(SemesterResponseDTO semesterStart, SemesterResponseDTO semesterNow, int curricolumnId)
        {
            SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
            Semester semesterS = _mapper.Map<Semester>(semesterStart);
            Semester semesterN = _mapper.Map<Semester>(semesterNow);
            return _mapper.Map<List<SubjectCurricolumResponseDTO>>(subjectCurricolumDAO.GetSubjectCurricolumniByTermNo(semesterS, semesterN, curricolumnId));
        }

        public IQueryable<SubjectCurricolumResponseDTO> GetSubjectCurricolums()
        {
            SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
            List<SubjectCurricolum> subjectCurricolums = subjectCurricolumDAO.GetSubjectCurricolums();
            return subjectCurricolums.Select(sc => _mapper.Map<SubjectCurricolumResponseDTO>(sc)).AsQueryable();
        }

        public bool SaveSubjectCurricolum(SubjectCurricolumCreateDTO subjectCurricolum)
        {
            try
            {
                SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
                bool result = subjectCurricolumDAO.AddSubjectCurricolum(_mapper.Map<SubjectCurricolum>(subjectCurricolum));
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

        public bool SaveSubjectCurricolumRange(List<SubjectCurricolumCreateDTO> subjectCurricolums)
        {
            try
            {
                SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
                bool result = subjectCurricolumDAO.AddSubjectCurricolumRange(_mapper.Map<List<SubjectCurricolum>>(subjectCurricolums));
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

        public bool UpdateSubjectCurricolum(SubjectCurricolumUpdateDTO subjectCurricolum)
        {
            try
            {
                SubjectCurricolumDAO subjectCurricolumDAO = new SubjectCurricolumDAO(_context);
                bool result = subjectCurricolumDAO.UpdateSubjectCurricolum(_mapper.Map<SubjectCurricolum>(subjectCurricolum));
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
