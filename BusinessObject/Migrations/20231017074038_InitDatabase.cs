using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    majorName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    majorCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<short>(type: "smallint", nullable: true),
                    semesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    subjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dateOfIssues = table.Column<DateTime>(type: "date", nullable: true),
                    numOfCredits = table.Column<short>(type: "smallint", nullable: true),
                    termNo = table.Column<short>(type: "smallint", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "((1))"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Curricolum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    curricolumName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    majorId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curricolum", x => x.id);
                    table.ForeignKey(
                        name: "FK_Curricolum_Major",
                        column: x => x.majorId,
                        principalTable: "Major",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: true),
                    idCard = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    middlename = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    image = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.id);
                    table.ForeignKey(
                        name: "FK_Account_Role",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "roleid");
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    semesterId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.id);
                    table.ForeignKey(
                        name: "FK_Class_Semester",
                        column: x => x.semesterId,
                        principalTable: "Semester",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GradeComponent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectId = table.Column<int>(type: "int", nullable: true),
                    gradeCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gradeItem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isFinal = table.Column<bool>(type: "bit", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    minScore = table.Column<short>(type: "smallint", nullable: true),
                    finalScoreId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeComponent", x => x.id);
                    table.ForeignKey(
                        name: "FK_GradeComponent_GradeComponent",
                        column: x => x.finalScoreId,
                        principalTable: "GradeComponent",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GradeComponent_Subject",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectCurricolum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectId = table.Column<int>(type: "int", nullable: true),
                    curricolumId = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    termNo = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCurricolum", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubjectCurricolum_Curricolum",
                        column: x => x.curricolumId,
                        principalTable: "Curricolum",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SubjectCurricolum_Subject",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    rollnumber = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    majorId = table.Column<int>(type: "int", nullable: true),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.rollnumber);
                    table.ForeignKey(
                        name: "FK_Student_Account",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Student_Major",
                        column: x => x.majorId,
                        principalTable: "Major",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectOfClass",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherId = table.Column<int>(type: "int", nullable: true),
                    classId = table.Column<int>(type: "int", nullable: true),
                    subjectId = table.Column<int>(type: "int", nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectOfClass", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubjectOfClass_Account",
                        column: x => x.teacherId,
                        principalTable: "Account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SubjectOfClass_Class",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SubjectOfClass_Subject",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StudyCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rollnumber = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    subjectOfClassId = table.Column<int>(type: "int", nullable: true),
                    tryTime = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "((1))"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCourse", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudyCourse_Student",
                        column: x => x.rollnumber,
                        principalTable: "Student",
                        principalColumn: "rollnumber");
                    table.ForeignKey(
                        name: "FK_StudyCourse_SubjectOfClass",
                        column: x => x.subjectOfClassId,
                        principalTable: "SubjectOfClass",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectResult",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studyCourseId = table.Column<int>(type: "int", nullable: true),
                    averageMark = table.Column<double>(type: "float", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true),
                    note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectResult", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubjectResult_StudyCourse",
                        column: x => x.studyCourseId,
                        principalTable: "StudyCourse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DetailScore",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gradeComponentId = table.Column<int>(type: "int", nullable: true),
                    subjectResultId = table.Column<int>(type: "int", nullable: true),
                    mark = table.Column<double>(type: "float", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedBy = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailScore", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailScore_GradeComponent",
                        column: x => x.gradeComponentId,
                        principalTable: "GradeComponent",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DetailScore_SubjectResult",
                        column: x => x.subjectResultId,
                        principalTable: "SubjectResult",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_roleid",
                table: "Account",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_Class_semesterId",
                table: "Class",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricolum_majorId",
                table: "Curricolum",
                column: "majorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailScore_gradeComponentId",
                table: "DetailScore",
                column: "gradeComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailScore_subjectResultId",
                table: "DetailScore",
                column: "subjectResultId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeComponent_finalScoreId",
                table: "GradeComponent",
                column: "finalScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeComponent_subjectId",
                table: "GradeComponent",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_accountId",
                table: "Student",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_majorId",
                table: "Student",
                column: "majorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourse_rollnumber",
                table: "StudyCourse",
                column: "rollnumber");

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourse_subjectOfClassId",
                table: "StudyCourse",
                column: "subjectOfClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurricolum_curricolumId",
                table: "SubjectCurricolum",
                column: "curricolumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurricolum_subjectId",
                table: "SubjectCurricolum",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectOfClass_classId",
                table: "SubjectOfClass",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectOfClass_subjectId",
                table: "SubjectOfClass",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectOfClass_teacherId",
                table: "SubjectOfClass",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectResult_studyCourseId",
                table: "SubjectResult",
                column: "studyCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailScore");

            migrationBuilder.DropTable(
                name: "SubjectCurricolum");

            migrationBuilder.DropTable(
                name: "GradeComponent");

            migrationBuilder.DropTable(
                name: "SubjectResult");

            migrationBuilder.DropTable(
                name: "Curricolum");

            migrationBuilder.DropTable(
                name: "StudyCourse");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "SubjectOfClass");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
