using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentorOnDemand.Migrations
{
    public partial class MOD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingDtls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(nullable: true),
                    progress = table.Column<int>(nullable: false),
                    commisionAmount = table.Column<double>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    avaRating = table.Column<double>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    timeSlot = table.Column<string>(nullable: true),
                    amountReceived = table.Column<double>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    userFirstName = table.Column<string>(nullable: true),
                    userLastName = table.Column<string>(nullable: true),
                    mentorId = table.Column<int>(nullable: false),
                    mentorFirstName = table.Column<string>(nullable: true),
                    mentorLastName = table.Column<string>(nullable: true),
                    skillId = table.Column<int>(nullable: false),
                    skillname = table.Column<string>(nullable: true),
                    accept = table.Column<bool>(nullable: false),
                    rejectNotify = table.Column<bool>(nullable: false),
                    trainingPaymentStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDtls", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e01d6265-6a60-4523-b7d2-31e83126cc90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b14cfb65-3509-412e-98f7-00d952e4630c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "6f447053-dabf-4f25-be8a-2ade9c009c1e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingDtls");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "63fdacbc-73a4-4a09-a127-9e15c387f491");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "07c823ff-296c-4d0c-b6b7-3143f2b7c7e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "bd95ea56-a013-40cd-8813-c19c0e908509");
        }
    }
}
