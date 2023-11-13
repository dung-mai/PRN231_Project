using BusinessObject.Models;
using Bussiness.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Repository.IRepository;
using Repository.Repository;
using System.Text;

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
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
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
