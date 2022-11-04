using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumsService.API.Migrations
{
    public partial class InitialMigrationLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("33759f86-a587-4937-b164-cbc81861a6c6"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("5922bfaa-680f-4b72-a290-8c1e160849de"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("f2562859-79d9-46b5-87ce-5998d19339ef"));

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("1add170e-4bbc-42a8-bce5-5dd26ee08376"), "A Forum for the Dune movie.", "dune_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("c9c43087-ae64-4d37-8874-b8adcd908310"), "A Forum for the Star Wars movies.", "sw_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f793b4b2-c484-4571-8e1f-a1f6a1c1250b"), "A Forum for the Harry Potter movies.", "hp_forum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("1add170e-4bbc-42a8-bce5-5dd26ee08376"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("c9c43087-ae64-4d37-8874-b8adcd908310"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("f793b4b2-c484-4571-8e1f-a1f6a1c1250b"));

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
    }
}
