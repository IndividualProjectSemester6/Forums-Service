using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumsService.API.Migrations
{
    public partial class DockerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("322a0aef-0e55-4bb9-b7a2-90f582fd9f35"), "A Forum for the Dune movie.", "dune_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("7f1871b3-9a57-4c99-af8d-50b55e8f48e7"), "A Forum for the Harry Potter movies.", "hp_forum" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), "A Forum for the Star Wars movies.", "sw_forum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("322a0aef-0e55-4bb9-b7a2-90f582fd9f35"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("7f1871b3-9a57-4c99-af8d-50b55e8f48e7"));

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"));

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
    }
}
