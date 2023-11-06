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
            CreateMap<AccountCreateDTO, AccountCreateStudentDTO>().ReverseMap();
            CreateMap<Class, ClassResponseDTO>().ReverseMap();
            CreateMap<Class, ClassUpdateDTO>().ReverseMap();
            CreateMap<Class, ClassCreateDTO>().ReverseMap();
            CreateMap<Curricolum, CurricolumResponseDTO>().ReverseMap();
            CreateMap<Curricolum, CurricolumUpdateDTO>().ReverseMap();
            CreateMap<Curricolum, CurricolumCreateDTO>().ReverseMap();
            CreateMap<Role, RoleResponseDTO>().ReverseMap();
            CreateMap<Role, RoleUpdateDTO>().ReverseMap();
            CreateMap<Role, RoleAddDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseResponseDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseUpdateDTO>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseCreateDTO>().ReverseMap();
            CreateMap<Subject, SubjectResponseDTO>().ReverseMap();
            CreateMap<Subject, SubjectUpdateDTO>().ReverseMap();
            CreateMap<Subject, SubjectCreateDTO>().ReverseMap();
            CreateMap<SubjectCurricolum, SubjectCurricolumResponseDTO>().ReverseMap();
            CreateMap<SubjectCurricolum, SubjectCurricolumUpdateDTO>().ReverseMap();
            CreateMap<SubjectCurricolum, SubjectCurricolumCreateDTO>().ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassResponseDTO>().ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassUpdateDTO>().ReverseMap();
            CreateMap<SubjectOfClass, SubjectOfClassCreateDTO>().ReverseMap();
            CreateMap<Teacher, TeacherResponseDTO>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDTO>().ReverseMap();
            CreateMap<Teacher, TeacherAddDTO>().ReverseMap();
        }

    }
}
