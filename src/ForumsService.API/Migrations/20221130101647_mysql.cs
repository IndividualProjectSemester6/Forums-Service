using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumsService.API.Migrations
{
    public partial class mysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("14ec41f0-9325-4457-9eb2-56ec72fd3e0b"), "A Forum for the Star Wars movies.", "sw_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("4c6bb740-f042-4e41-a7bd-d21a1be5ee07"), "A Forum for the Harry Potter movies.", "hp_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("c86946bf-0fc3-4d96-8749-c50b91334538"), "A Forum for the Dune movie.", "dune_forum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
