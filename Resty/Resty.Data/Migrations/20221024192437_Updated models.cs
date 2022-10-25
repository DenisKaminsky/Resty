using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resty.Data.Migrations
{
    public partial class Updatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                table: "BlogUserComments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                table: "BlogUserComments");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 15, 0, 21, 696, DateTimeKind.Utc).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 24, 14, 0, 21, 696, DateTimeKind.Utc).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDateUtc",
                value: new DateTime(2022, 7, 16, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 14, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 19, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8138));
        }
    }
}
