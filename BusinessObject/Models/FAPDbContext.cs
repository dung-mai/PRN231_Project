using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class PRN221_ProjectContext : DbContext
    {
        public PRN221_ProjectContext()
        {
        }

        public PRN221_ProjectContext(DbContextOptions<PRN221_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Curricolum> Curricolums { get; set; } = null!;
        public virtual DbSet<DetailScore> DetailScores { get; set; } = null!;
        public virtual DbSet<GradeComponent> GradeComponents { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudyCourse> StudyCourses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectCurricolum> SubjectCurricolums { get; set; } = null!;
        public virtual DbSet<SubjectOfClass> SubjectOfClasses { get; set; } = null!;
        public virtual DbSet<SubjectResult> SubjectResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\DUNG;database=PRN221_Project;uid=sa;pwd=123456;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IdCard)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("idCard");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(20)
                    .HasColumnName("middlename");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("className");

                entity.Property(e => e.SemesterId).HasColumnName("semesterId");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK_Class_Semester");
            });

            modelBuilder.Entity<Curricolum>(entity =>
            {
                entity.ToTable("Curricolum");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurricolumName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("curricolumName");

                entity.Property(e => e.MajorId).HasColumnName("majorId");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Curricolums)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_Curricolum_Major");
            });

            modelBuilder.Entity<DetailScore>(entity =>
            {
                entity.ToTable("DetailScore");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.GradeComponentId).HasColumnName("gradeComponentId");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.SubjectResultId).HasColumnName("subjectResultId");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

                entity.HasOne(d => d.GradeComponent)
                    .WithMany(p => p.DetailScores)
                    .HasForeignKey(d => d.GradeComponentId)
                    .HasConstraintName("FK_DetailScore_GradeComponent");

                entity.HasOne(d => d.SubjectResult)
                    .WithMany(p => p.DetailScores)
                    .HasForeignKey(d => d.SubjectResultId)
                    .HasConstraintName("FK_DetailScore_SubjectResult");
            });

            modelBuilder.Entity<GradeComponent>(entity =>
            {
                entity.ToTable("GradeComponent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FinalScoreId).HasColumnName("finalScoreId");

                entity.Property(e => e.GradeCategory)
                    .HasMaxLength(50)
                    .HasColumnName("gradeCategory");

                entity.Property(e => e.GradeItem)
                    .HasMaxLength(50)
                    .HasColumnName("gradeItem");

                entity.Property(e => e.IsFinal).HasColumnName("isFinal");

                entity.Property(e => e.MinScore).HasColumnName("minScore");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(4, 1)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.FinalScore)
                    .WithMany(p => p.InverseFinalScore)
                    .HasForeignKey(d => d.FinalScoreId)
                    .HasConstraintName("FK_GradeComponent_GradeComponent");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GradeComponents)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_GradeComponent_Subject");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MajorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("majorCode");

                entity.Property(e => e.MajorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("majorName");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.SemesterName)
                    .HasMaxLength(50)
                    .HasColumnName("semesterName");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Rollnumber);

                entity.ToTable("Student");

                entity.Property(e => e.Rollnumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("rollnumber");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.MajorId).HasColumnName("majorId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Student_Account");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_Student_Major");
            });

            modelBuilder.Entity<StudyCourse>(entity =>
            {
                entity.ToTable("StudyCourse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rollnumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("rollnumber");

                entity.Property(e => e.SubjectOfClassId).HasColumnName("subjectOfClassId");

                entity.Property(e => e.TryTime)
                    .HasColumnName("tryTime")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.RollnumberNavigation)
                    .WithMany(p => p.StudyCourses)
                    .HasForeignKey(d => d.Rollnumber)
                    .HasConstraintName("FK_StudyCourse_Student");

                entity.HasOne(d => d.SubjectOfClass)
                    .WithMany(p => p.StudyCourses)
                    .HasForeignKey(d => d.SubjectOfClassId)
                    .HasConstraintName("FK_StudyCourse_SubjectOfClass");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfIssues)
                    .HasColumnType("date")
                    .HasColumnName("dateOfIssues");

                entity.Property(e => e.NumOfCredits).HasColumnName("numOfCredits");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(10)
                    .HasColumnName("subjectCode");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(100)
                    .HasColumnName("subjectName");

                entity.Property(e => e.TermNo).HasColumnName("termNo");
            });

            modelBuilder.Entity<SubjectCurricolum>(entity =>
            {
                entity.ToTable("SubjectCurricolum");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurricolumId).HasColumnName("curricolumId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.TermNo).HasColumnName("termNo");

                entity.HasOne(d => d.Curricolum)
                    .WithMany(p => p.SubjectCurricolums)
                    .HasForeignKey(d => d.CurricolumId)
                    .HasConstraintName("FK_SubjectCurricolum_Curricolum");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectCurricolums)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_SubjectCurricolum_Subject");
            });

            modelBuilder.Entity<SubjectOfClass>(entity =>
            {
                entity.ToTable("SubjectOfClass");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubjectOfClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_SubjectOfClass_Class");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectOfClasses)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_SubjectOfClass_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectOfClasses)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_SubjectOfClass_Account");
            });

            modelBuilder.Entity<SubjectResult>(entity =>
            {
                entity.ToTable("SubjectResult");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AverageMark).HasColumnName("averageMark");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .HasColumnName("note");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StudyCourseId).HasColumnName("studyCourseId");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

                entity.HasOne(d => d.StudyCourse)
                    .WithMany(p => p.SubjectResults)
                    .HasForeignKey(d => d.StudyCourseId)
                    .HasConstraintName("FK_SubjectResult_StudyCourse");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
