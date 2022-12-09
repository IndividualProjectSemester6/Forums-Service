using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumsService.API.Migrations
{
    public partial class Localhost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("6d61e13a-ccc5-4f00-add9-a31b9a8f3ad1"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("8e0b0cee-0e4a-498c-a429-faece79c5722"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("90d307e6-7710-4f51-8d00-f13bd6eae519"));

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("5d5199cc-fd32-4f57-9106-fa1de98e5859"), "A Forum for the Dune movie.", "dune_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("b2b715cb-1c17-4d4d-a269-8bcbe7734fc1"), "A Forum for the Harry Potter movies.", "hp_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("e9039d6e-82ab-4bec-8fbe-387062c2a76c"), "A Forum for the Star Wars movies.", "sw_forum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("5d5199cc-fd32-4f57-9106-fa1de98e5859"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("b2b715cb-1c17-4d4d-a269-8bcbe7734fc1"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("e9039d6e-82ab-4bec-8fbe-387062c2a76c"));

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("6d61e13a-ccc5-4f00-add9-a31b9a8f3ad1"), "A Forum for the Star Wars movies.", "sw_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("8e0b0cee-0e4a-498c-a429-faece79c5722"), "A Forum for the Dune movie.", "dune_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("90d307e6-7710-4f51-8d00-f13bd6eae519"), "A Forum for the Harry Potter movies.", "hp_forum" });
        }
    }
}
