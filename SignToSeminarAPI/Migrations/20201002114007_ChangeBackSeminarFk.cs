using Microsoft.EntityFrameworkCore.Migrations;

namespace SignToSeminarAPI.Migrations
{
    public partial class ChangeBackSeminarFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_Speakers_speakerId",
                table: "Seminars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Seminars_speakerId",
                table: "Seminars");

            migrationBuilder.DropColumn(
                name: "speakerId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "speakerId",
                table: "Seminars");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Speakers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SeminarOfSpeakerId",
                table: "Seminars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars",
                column: "SeminarOfSpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_Speakers_SeminarOfSpeakerId",
                table: "Seminars",
                column: "SeminarOfSpeakerId",
                principalTable: "Speakers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_Speakers_SeminarOfSpeakerId",
                table: "Seminars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "SeminarOfSpeakerId",
                table: "Seminars");

            migrationBuilder.AddColumn<int>(
                name: "speakerId",
                table: "Speakers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "speakerId",
                table: "Seminars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "speakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_speakerId",
                table: "Seminars",
                column: "speakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_Speakers_speakerId",
                table: "Seminars",
                column: "speakerId",
                principalTable: "Speakers",
                principalColumn: "speakerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
