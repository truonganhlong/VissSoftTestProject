using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vissoft.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class updateLessonAndThematic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thematic_Lesson_lesson_id",
                table: "Thematic");

            migrationBuilder.DropIndex(
                name: "IX_Thematic_lesson_id",
                table: "Thematic");

            migrationBuilder.DropColumn(
                name: "lesson_id",
                table: "Thematic");

            migrationBuilder.AddColumn<int>(
                name: "thematic_id",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_thematic_id",
                table: "Lesson",
                column: "thematic_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Thematic_thematic_id",
                table: "Lesson",
                column: "thematic_id",
                principalTable: "Thematic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Thematic_thematic_id",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_thematic_id",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "thematic_id",
                table: "Lesson");

            migrationBuilder.AddColumn<int>(
                name: "lesson_id",
                table: "Thematic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Thematic_lesson_id",
                table: "Thematic",
                column: "lesson_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Thematic_Lesson_lesson_id",
                table: "Thematic",
                column: "lesson_id",
                principalTable: "Lesson",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
