using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StartSemeterId",
                table: "Curricolum",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curricolum_StartSemeterId",
                table: "Curricolum",
                column: "StartSemeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricolum_Semester",
                table: "Curricolum",
                column: "StartSemeterId",
                principalTable: "Semester",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curricolum_Semester",
                table: "Curricolum");

            migrationBuilder.DropIndex(
                name: "IX_Curricolum_StartSemeterId",
                table: "Curricolum");

            migrationBuilder.DropColumn(
                name: "StartSemeterId",
                table: "Curricolum");
        }
    }
}
