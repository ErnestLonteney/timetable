using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Migrations.EFLogger
{
    public partial class LogDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogElements",
                columns: table => new
                {
                    CategoryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogElements", x => new { x.CategoryName, x.Date });
                    table.ForeignKey(
                        name: "FK_LogElements_RequestElements_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestElements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogElements_RequestId",
                table: "LogElements",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogElements");

            migrationBuilder.DropTable(
                name: "RequestElements");
        }
    }
}
