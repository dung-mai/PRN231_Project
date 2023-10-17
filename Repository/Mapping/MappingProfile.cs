using Bussiness.DTO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<DetailScore, DetailScoreDTO>().ReverseMap();
            CreateMap<GradeComponent, GradeComponentDTO>().ReverseMap();
            CreateMap<Major, MajorDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Semester, SemesterDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.StudyCourses, opt => opt.MapFrom(src => src.StudyCourses))
                    .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                .ReverseMap()
                    .ForMember(dest => dest.StudyCourses, opt => opt.MapFrom(src => src.StudyCourses))
                    .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account));
            CreateMap<StudyCourse, StudyCourseDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResultDTO>().ReverseMap();
        }

    }
}
