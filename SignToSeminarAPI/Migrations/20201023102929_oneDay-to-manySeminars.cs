using Microsoft.EntityFrameworkCore.Migrations;

namespace SignToSeminarAPI.Migrations
{
    public partial class oneDaytomanySeminars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaySeminars");

            migrationBuilder.AddColumn<int>(
                name: "SeminarOfDayId",
                table: "Seminars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_SeminarOfDayId",
                table: "Seminars",
                column: "SeminarOfDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_Days_SeminarOfDayId",
                table: "Seminars",
                column: "SeminarOfDayId",
                principalTable: "Days",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_Days_SeminarOfDayId",
                table: "Seminars");

            migrationBuilder.DropIndex(
                name: "IX_Seminars_SeminarOfDayId",
                table: "Seminars");

            migrationBuilder.DropColumn(
                name: "SeminarOfDayId",
                table: "Seminars");

            migrationBuilder.CreateTable(
                name: "DaySeminars",
                columns: table => new
                {
                    dayId = table.Column<int>(type: "int", nullable: false),
                    seminarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySeminars", x => new { x.dayId, x.seminarId });
                    table.ForeignKey(
                        name: "FK_DaySeminars_Days_dayId",
                        column: x => x.dayId,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaySeminars_Seminars_seminarId",
                        column: x => x.seminarId,
                        principalTable: "Seminars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaySeminars_seminarId",
                table: "DaySeminars",
                column: "seminarId");
        }
    }
}
