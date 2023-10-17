using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class Ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectOfClass_Account",
                table: "SubjectOfClass");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "SubjectResult",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    AccountId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Teacher_Account_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "Account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectResult_TeacherId",
                table: "SubjectResult",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AccountId1",
                table: "Teacher",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectOfClass_Account",
                table: "SubjectOfClass",
                column: "teacherId",
                principalTable: "Teacher",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectResult_Teacher_TeacherId",
                table: "SubjectResult",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectOfClass_Account",
                table: "SubjectOfClass");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectResult_Teacher_TeacherId",
                table: "SubjectResult");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectResult_TeacherId",
                table: "SubjectResult");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SubjectResult");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectOfClass_Account",
                table: "SubjectOfClass",
                column: "teacherId",
                principalTable: "Account",
                principalColumn: "id");
        }
    }
}
