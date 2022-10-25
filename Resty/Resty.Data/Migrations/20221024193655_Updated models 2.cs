using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resty.Data.Migrations
{
    public partial class Updatedmodels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRoles",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_Name",
                table: "UserRoles",
                newName: "IX_UserRoles_Type");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDateUtc",
                value: new DateTime(2022, 7, 16, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 14, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 19, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2952));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserRoles",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_Type",
                table: "UserRoles",
                newName: "IX_UserRoles_Name");

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 19, 24, 37, 82, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 16, 24, 37, 82, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 19, 24, 37, 82, DateTimeKind.Utc).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 18, 24, 37, 82, DateTimeKind.Utc).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 17, 24, 37, 82, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDateUtc",
                value: new DateTime(2022, 7, 16, 19, 24, 37, 82, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 14, 19, 24, 37, 82, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 19, 19, 24, 37, 82, DateTimeKind.Utc).AddTicks(6361));
        }
    }
}
