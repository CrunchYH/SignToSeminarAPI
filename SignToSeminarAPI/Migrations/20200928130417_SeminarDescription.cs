using Microsoft.EntityFrameworkCore.Migrations;

namespace SignToSeminarAPI.Migrations 
{
    public partial class SeminarDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Seminars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Seminars");
        }
    }
}
