using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.Account;
using DTO.Request.Class;
using DTO.Request.Curricolum;
using DTO.Request.DetailScore;
using DTO.Request.GradeComponent;
using DTO.Request.Major;
using DTO.Request.Role;
using DTO.Request.Semester;
using DTO.Request.Student;
using DTO.Request.StudyCourse;
using DTO.Request.Subject;
using DTO.Request.SubjectCurricolum;
using DTO.Request.SubjectOfClass;
using DTO.Request.SubjectResult;
using DTO.Request.Teacher;
using DTO.Response.Account;
using DTO.Response.Class;
using DTO.Response.Curricolum;
using DTO.Response.DetailScore;
using DTO.Response.GradeComponent;
using DTO.Response.Major;
using DTO.Response.Role;
using DTO.Response.Semester;
using DTO.Response.Student;
using DTO.Response.StudyCourse;
using DTO.Response.Subject;
using DTO.Response.SubjectCurricolum;
using DTO.Response.SubjectOfClass;
using DTO.Response.SubjectResult;
using DTO.Response.Teacher;

namespace Bussiness.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<DetailScore, DetailScoreAddDTO>().ReverseMap();
            CreateMap<DetailScore, DetailScoreUpdateDTO>().ReverseMap();
            CreateMap<DetailScore, DetailScoreResponseDTO>().ReverseMap();
            CreateMap<DetailScore, DetailScoreUpdateMarkDTO>().ReverseMap();
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
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResultResponseDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResultAddDTO>().ReverseMap();
            CreateMap<SubjectResult, SubjectResultUpdateDTO>().ReverseMap();
            CreateMap<Account, AccountResponseDTO>().ReverseMap();
            CreateMap<Account, AccountUpdateDTO>().ReverseMap();
            CreateMap<Account, AccountCreateDTO>().ReverseMap();
            CreateMap<Account, AccountCreateStudentDTO>().ReverseMap();
            CreateMap<Account, AccountUpdateStudentDTO>().ReverseMap();
            CreateMap<Account, AccountCreateTeacherDTO>().ReverseMap();
            CreateMap<Account, AccountUpdateTeacherDTO>().ReverseMap();
            CreateMap<AccountCreateDTO, AccountCreateStudentDTO>().ReverseMap();
            CreateMap<Class, ClassResponseDTO>().ReverseMap();
            CreateMap<Class, ClassUpdateDTO>().ReverseMap();
            CreateMap<Class, ClassCreateDTO>().ReverseMap();
            CreateMap<Class, ClassReponseAddDTO>().ReverseMap();
            CreateMap<Curricolum, CurricolumResponseDTO>()
                .ForMember(des => des.Subjects, opt => opt.MapFrom(src => src.SubjectCurricolums))
                .ReverseMap();
            CreateMap<Curricolum, CurricolumUpdateDTO>()
                .ForMember(des => des.Subjects, opt => opt.MapFrom(src => src.SubjectCurricolums))
                .ReverseMap();
            CreateMap<Curricolum, CurricolumCreateDTO>().ReverseMap();
            CreateMap<Role, RoleResponseDTO>().ReverseMap();
            CreateMap<Role, RoleUpdateDTO>().ReverseMap();
            CreateMap<Role, RoleAddDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseResponseDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseUpdateDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseCreateDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseResponseAllDTO>().ReverseMap();
            CreateMap<Subject, SubjectResponseDTO>().ReverseMap();
            CreateMap<Subject, SubjectUpdateDTO>().ReverseMap();
            CreateMap<Subject, SubjectCreateDTO>().ReverseMap();
            CreateMap<SubjectCurricolum, SubjectCurricolumResponseDTO>().ReverseMap();
            CreateMap<SubjectCurricolum, SubjectCurricolumUpdateDTO>().ReverseMap();
            CreateMap<SubjectCurricolum, SubjectCurricolumCreateDTO>().ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassResponseDTO>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(act => act.Class.ClassName))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(act => act.Subject.SubjectName))
                .ForMember(dest => dest.SubjectCode, opt => opt.MapFrom(act => act.Subject.SubjectCode))
                .ForMember(dest => dest.TeacherCode, opt => opt.MapFrom(act => act.Teacher.AccountId))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(act => $"{act.Teacher.Account.Firstname} {act.Teacher.Account.Middlename} {act.Teacher.Account.Lastname}"))
                .ReverseMap();
            CreateMap<Student, StudentResponseStudyCourseDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(act => $"{act.Account.Firstname} {act.Account.Middlename} {act.Account.Lastname}"))
                .ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassUpdateDTO>().ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassCreateDTO>().ReverseMap();
            CreateMap<Teacher, TeacherResponseDTO>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDTO>().ReverseMap();
            CreateMap<Teacher, TeacherAddDTO>().ReverseMap();
        }

    }
}
