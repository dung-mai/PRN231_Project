using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurricolumId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurricolumId",
                table: "Student",
                column: "CurricolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Curricolum_CurricolumId",
                table: "Student",
                column: "CurricolumId",
                principalTable: "Curricolum",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Curricolum_CurricolumId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CurricolumId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurricolumId",
                table: "Student");
        }
    }
}
