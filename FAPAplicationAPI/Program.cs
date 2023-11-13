using BusinessObject.Models;
using Bussiness.Mapping;
using Microsoft.AspNetCore.OData;
using Repository.IRepository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FAPDbContext>(opt => builder.Configuration.GetConnectionString("finalproject"));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ICurricolumRepository, CurricolumRepository>();
builder.Services.AddScoped<IDetailScoreRepository, DetailScoreRepository>();
builder.Services.AddScoped<IGradeComponentRepository, GradeComponentRepository>();
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudyCourseRepository, StudyCourseRepository>();
builder.Services.AddScoped<ISubjectCurricolumRepository, SubjectCurricolumRepository>();
builder.Services.AddScoped<ISubjectOfClassRepository, SubjectOfClassRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectResultRepository, SubjectResultRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IClassGradeRepository, ClassGradeRepository>();
builder.Services.AddControllers().AddOData(option => option.Select()
.Filter().OrderBy().Expand().SetMaxTop(100)
.Expand());
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
