using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resty.Data.Migrations
{
    public partial class Updatedmodels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Blogs",
                newName: "Preview");

            migrationBuilder.CreateSequence<int>(
                name: "Tags_Seq",
                schema: "public",
                startValue: 9L);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"Tags_Seq\"')"),
                    Title = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    BlogsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => new { x.BlogsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BlogTags_Blogs_BlogsId",
                        column: x => x.BlogsId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 8, 11, 52, 799, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 5, 11, 52, 799, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 8, 11, 52, 799, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 7, 11, 52, 799, DateTimeKind.Utc).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 6, 11, 52, 799, DateTimeKind.Utc).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 6, 11, 52, 799, DateTimeKind.Utc).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 5, 11, 52, 799, DateTimeKind.Utc).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 4, 11, 52, 799, DateTimeKind.Utc).AddTicks(9322));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, ".NET 6" },
                    { 3, "PostgreSQL" },
                    { 4, "SignalR" },
                    { 5, "Web-design" },
                    { 6, "Android" },
                    { 7, "IT-companies" },
                    { 8, "Security" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDateUtc",
                value: new DateTime(2022, 7, 17, 8, 11, 52, 799, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 15, 8, 11, 52, 799, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 20, 8, 11, 52, 799, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.InsertData(
                table: "BlogTags",
                columns: new[] { "BlogsId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 6 },
                    { 6, 7 },
                    { 6, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_TagsId",
                table: "BlogTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Title",
                table: "Tags",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropSequence(
                name: "Tags_Seq",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "Preview",
                table: "Blogs",
                newName: "Description");

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
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 6, 16, 57, 37, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 5, 16, 57, 37, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 5, 16, 57, 37, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 4, 16, 57, 37, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 10, 25, 3, 16, 57, 37, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDateUtc",
                value: new DateTime(2022, 7, 17, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 15, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDateUtc",
                value: new DateTime(2022, 10, 20, 7, 16, 57, 37, DateTimeKind.Utc).AddTicks(6361));
        }
    }
}
