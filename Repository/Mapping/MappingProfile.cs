using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.DetailScore;
using DTO.Request.GradeComponent;
using DTO.Request.Major;
using DTO.Request.Semester;
using DTO.Request.Student;
using DTO.Request.SubjectResult;
using DTO.Response.DetailScore;
using DTO.Response.GradeComponent;
using DTO.Response.Major;
using DTO.Response.Semester;
using DTO.Response.Student;
using DTO.Response.Subject;

namespace Bussiness.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<DetailScore, DetailScoreDAO>().ReverseMap();
            CreateMap<DetailScore, DetailScoreUpdateDTO>().ReverseMap();
            CreateMap<DetailScore, DetailScoreResponseDTO>().ReverseMap();
            CreateMap<GradeComponent, GradeComponentAddDTO>().ReverseMap();
            CreateMap<GradeComponent, GradeComponentUpdateDTO>().ReverseMap();
            CreateMap<GradeComponent, GradeComponentResponseDTO>().ReverseMap();
            CreateMap<Major, MajorAddDTO>().ReverseMap();
            CreateMap<Major, MajorUpdateDTO>().ReverseMap();
            CreateMap<Major, MajorResponseDTO>().ReverseMap();
            CreateMap<Semester, SemesterAddDTO>().ReverseMap();
            CreateMap<Semester, SemesterUpdateDTO>().ReverseMap();
            CreateMap<Semester, SemesterResponseDTO>().ReverseMap();
            CreateMap<Student, StudentAddDTO>().ReverseMap();
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResponseDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResultAddDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResultUpdateDTO>().ReverseMap();


        }

    }
}
