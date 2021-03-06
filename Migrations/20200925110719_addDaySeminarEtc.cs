﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SignToSeminarAPI.Migrations
{
    public partial class addDaySeminarEtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Seminars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    SeminarOfSpeakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminars", x => x.id);
                    table.ForeignKey(
                        name: "FK_Seminars_Speakers_SeminarOfSpeakerId",
                        column: x => x.SeminarOfSpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaySeminars",
                columns: table => new
                {
                    seminarId = table.Column<int>(nullable: false),
                    dayId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UserSeminar",
                columns: table => new
                {
                    seminarId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeminar", x => new { x.userId, x.seminarId });
                    table.ForeignKey(
                        name: "FK_UserSeminar_Seminars_seminarId",
                        column: x => x.seminarId,
                        principalTable: "Seminars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSeminar_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaySeminars_seminarId",
                table: "DaySeminars",
                column: "seminarId");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_SeminarOfSpeakerId",
                table: "Seminars",
                column: "SeminarOfSpeakerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSeminar_seminarId",
                table: "UserSeminar",
                column: "seminarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaySeminars");

            migrationBuilder.DropTable(
                name: "UserSeminar");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Seminars");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
