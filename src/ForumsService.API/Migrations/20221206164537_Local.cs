using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumsService.API.Migrations
{
    public partial class Local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("66f9fcc0-ad97-4422-bddd-7c208eef5be5"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("89816887-fdff-4c0f-90d0-05178002fe46"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("b1b263b4-c588-4add-89c2-eded5632d0a1"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("66f9fcc0-ad97-4422-bddd-7c208eef5be5"), "A Forum for the Dune movie.", "dune_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("89816887-fdff-4c0f-90d0-05178002fe46"), "A Forum for the Harry Potter movies.", "hp_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("b1b263b4-c588-4add-89c2-eded5632d0a1"), "A Forum for the Star Wars movies.", "sw_forum" });
        }
    }
}
