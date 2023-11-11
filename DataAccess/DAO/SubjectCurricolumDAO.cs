using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccess.DAO
{
    public class SubjectCurricolumDAO
    {
        FAPDbContext _context;
        public SubjectCurricolumDAO(FAPDbContext context)
        {
            _context = context;
        }

        public List<SubjectCurricolum> GetSubjectCurricolums()
        {
            return _context.SubjectCurricolums
                .Where(sc => !sc.IsDelete)
                .ToList();
        }

        public SubjectCurricolum? GetSubjectCurricolum(int id)
        {
            return _context.SubjectCurricolums
                .FirstOrDefault(sc => sc.Id == id && !sc.IsDelete);
        }

        public bool AddSubjectCurricolum(SubjectCurricolum subjectCurricolum)
        {
            if (subjectCurricolum != null)
            {
                _context.SubjectCurricolums.Add(subjectCurricolum);
                return true;
            }
            return false;
        }

        public bool DeleteSubjectCurricolum(int subjectCurricolumId)
        {
            SubjectCurricolum? subjectCurricolum = _context.SubjectCurricolums.FirstOrDefault(sc => sc.Id == subjectCurricolumId && !sc.IsDelete);
            if (subjectCurricolum != null)
            {
                subjectCurricolum.IsDelete = true;
                subjectCurricolum.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool UpdateSubjectCurricolum(SubjectCurricolum _subjectCurricolum)
        {
            SubjectCurricolum? subjectCurricolum = _context.SubjectCurricolums
                .FirstOrDefault(sc => sc.Id == _subjectCurricolum.Id && !sc.IsDelete);
            if (subjectCurricolum != null)
            {
                subjectCurricolum.SubjectId = _subjectCurricolum.SubjectId;
                subjectCurricolum.CurricolumId = _subjectCurricolum.CurricolumId;
                subjectCurricolum.Status = _subjectCurricolum.Status;
                subjectCurricolum.TermNo = _subjectCurricolum.TermNo;
                subjectCurricolum.UpdatedAt = DateTime.Now;
                subjectCurricolum.UpdatedBy = _subjectCurricolum.UpdatedBy;
                subjectCurricolum.IsDelete = _subjectCurricolum.IsDelete;
                return true;
            }
            return false;
        }

        public bool AddSubjectCurricolumRange(List<SubjectCurricolum> subjectCurricolums)
        {
            if (subjectCurricolums != null && subjectCurricolums.Count > 0)
            {
                _context.SubjectCurricolums.AddRange(subjectCurricolums);
                return true;
            }
            return false;
        }

        public List<SubjectCurricolum> GetSubjectCurricolumsById(int id)
        {
            return _context.SubjectCurricolums
                .Include(sc => sc.Subject)
                .Where(sc => !sc.IsDelete && sc.CurricolumId == id)
                .ToList();
        }

        public List<SubjectCurricolum> GetSubjectCurricolumniByTermNo(Semester semesterStart, Semester semesterNow, int curricolumnId)
        {
            
            int term = 0;
            int year = (int)(semesterNow.Year - semesterStart.Year);
            int count = 0;
            switch (year)
            {
                case 1:
                    count = 3;
                    break;
                case 2:
                    count = 6;
                    break;
                default:
                    break;
            }
            switch (semesterStart.SemesterName)
            {
                case "Spring":
                    switch (semesterNow.SemesterName)
                    {
                        case "Spring":
                            term = 1 + count;
                            break;
                        case "Summer":
                            term = 2 + count;
                            break;
                        case "Fall":
                            term = 3 + count;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Summer":
                    switch (semesterStart.SemesterName)
                    {
                        case "Spring":
                            term = 3 + count;
                            break;
                        case "Summer":
                            term = 1 + count;
                            break;
                        case "Fall":
                            term = 2 + count;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Fall":
                    switch (semesterStart.SemesterName)
                    {
                        case "Spring":
                            term = 2 + count;
                            break;
                        case "Summer":
                            term = 3 + count;
                            break;
                        case "Fall":
                            term = 1 + count;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            List<SubjectCurricolum> subjectCurricolums = GetSubjectCurricolumsById(curricolumnId).Where(c => c.TermNo == term).ToList();
            return subjectCurricolums;

        }
    }
}
