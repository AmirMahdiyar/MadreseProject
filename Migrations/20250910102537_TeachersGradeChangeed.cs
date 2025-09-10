using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MadreseV6.Migrations
{
    /// <inheritdoc />
    public partial class TeachersGradeChangeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersGrades_Teachers_TeacherId",
                table: "TeachersGrades");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersGrades_Teachers_TeacherId",
                table: "TeachersGrades",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersGrades_Teachers_TeacherId",
                table: "TeachersGrades");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersGrades_Teachers_TeacherId",
                table: "TeachersGrades",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
