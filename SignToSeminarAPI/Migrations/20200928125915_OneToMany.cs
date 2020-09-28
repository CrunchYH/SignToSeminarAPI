using Microsoft.EntityFrameworkCore.Migrations;

namespace SignToSeminarAPI.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars",
                column: "SeminarOfSpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars",
                column: "SeminarOfSpeakerId",
                unique: true);
        }
    }
}
