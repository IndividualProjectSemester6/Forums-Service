using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumsService.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("33759f86-a587-4937-b164-cbc81861a6c6"), "A Forum for the Dune movie.", "dune_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("5922bfaa-680f-4b72-a290-8c1e160849de"), "A Forum for the Harry Potter movies.", "hp_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f2562859-79d9-46b5-87ce-5998d19339ef"), "A Forum for the Star Wars movies.", "sw_forum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
