using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resty.Data.Migrations
{
    public partial class Updatedmodels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropSequence(
                name: "UserRoles_Seq",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.RestartSequence(
                name: "Blogs_Seq",
                schema: "public",
                startValue: 7L);

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 4, 16, 57, 37, DateTimeKind.Utc).AddTicks(6899));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateUtc", "Type" },
                values: new object[] { new DateTime(2022, 10, 25, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6625), "Post" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateUtc", "Type" },
                values: new object[] { new DateTime(2022, 10, 25, 6, 16, 57, 37, DateTimeKind.Utc).AddTicks(6627), "Post" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDateUtc", "Type" },
                values: new object[] { new DateTime(2022, 10, 25, 5, 16, 57, 37, DateTimeKind.Utc).AddTicks(6628), "Post" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedDateUtc", "Description", "Title", "Type" },
                values: new object[,]
                {
                    { 4, 1, "TEST NEWS 1", new DateTime(2022, 10, 25, 5, 16, 57, 37, DateTimeKind.Utc).AddTicks(6629), null, "DenisAdmin News 1", "News" },
                    { 5, 1, "TEST NEWS 2", new DateTime(2022, 10, 25, 4, 16, 57, 37, DateTimeKind.Utc).AddTicks(6630), null, "DenisAdmin News 3", "News" },
                    { 6, 1, "TEST NEWS 3", new DateTime(2022, 10, 25, 3, 16, 57, 37, DateTimeKind.Utc).AddTicks(6630), null, "DenisAdmin News 3", "News" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Role", "StartDateUtc" },
                values: new object[] { "Admin", new DateTime(2022, 7, 17, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Role", "StartDateUtc" },
                values: new object[] { "GuestUser", new DateTime(2022, 10, 15, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6359) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Role", "StartDateUtc" },
                values: new object[] { "PrimeUser", new DateTime(2022, 10, 20, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6361) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Blogs");

            migrationBuilder.CreateSequence<int>(
                name: "UserRoles_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.RestartSequence(
                name: "Blogs_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"UserRoles_Seq\"')"),
                    Type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 16, 36, 55, 409, DateTimeKind.Utc).AddTicks(3295));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 18, 36, 55, 409, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 17, 36, 55, 409, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "GuestUser" },
                    { 3, "PrimeUser" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RoleId", "StartDateUtc" },
                values: new object[] { 1, new DateTime(2022, 7, 16, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RoleId", "StartDateUtc" },
                values: new object[] { 2, new DateTime(2022, 10, 14, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RoleId", "StartDateUtc" },
                values: new object[] { 3, new DateTime(2022, 10, 19, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Type",
                table: "UserRoles",
                column: "Type",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
