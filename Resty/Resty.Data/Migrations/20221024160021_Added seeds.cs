using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Resty.Data.Migrations
{
    public partial class Addedseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateSequence<int>(
                name: "Blogs_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.CreateSequence<int>(
                name: "BlogUserBookmark_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.CreateSequence<int>(
                name: "BlogUserComment_Seq",
                schema: "public",
                startValue: 3L);

            migrationBuilder.CreateSequence<int>(
                name: "BlogUserReview_Seq",
                schema: "public",
                startValue: 7L);

            migrationBuilder.CreateSequence<int>(
                name: "UserRoles_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.CreateSequence<int>(
                name: "Users_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"Users_Seq\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"UserRoles_Seq\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogUserReviews",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"BlogUserReview_Seq\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogUserComments",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"BlogUserComment_Seq\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogUserBookmarks",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"BlogUserBookmark_Seq\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Blogs",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"Blogs_Seq\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "GuestUser" },
                    { 3, "PrimeUser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EndDateUtc", "FirstName", "LastName", "PasswordHash", "Rating", "RoleId", "StartDateUtc", "Username" },
                values: new object[,]
                {
                    { 1, "deniskaminsky123@mail.ru", null, "Denis", "Kaminsky", "21232f297a57a5a743894a0e4a801fc3", 900, 1, new DateTime(2022, 7, 16, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8131), "DenisAdmin" },
                    { 2, "deniskaminskyGuest@mail.ru", null, "Denis", "KaminskyGuest", "21232f297a57a5a743894a0e4a801fc3", 1, 2, new DateTime(2022, 10, 14, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8136), "DenisGuest" },
                    { 3, "deniskaminskyPrime@mail.ru", null, "Denis", "KaminskyPrime", "21232f297a57a5a743894a0e4a801fc3", 3, 3, new DateTime(2022, 10, 19, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8138), "DenisPrime" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedDateUtc", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, "TEST", new DateTime(2022, 10, 24, 16, 0, 21, 696, DateTimeKind.Utc).AddTicks(8302), "Blog created by DenisAdmin", "DenisAdmin Blog" },
                    { 2, 2, "TEST 2", new DateTime(2022, 10, 24, 15, 0, 21, 696, DateTimeKind.Utc).AddTicks(8303), "Blog created by DenisGuest", "DenisGuest Blog" },
                    { 3, 3, "TEST 3", new DateTime(2022, 10, 24, 14, 0, 21, 696, DateTimeKind.Utc).AddTicks(8305), null, "DenisPrime Blog" }
                });

            migrationBuilder.InsertData(
                table: "BlogUserBookmarks",
                columns: new[] { "Id", "BlogId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 2 },
                    { 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "BlogUserComments",
                columns: new[] { "Id", "BlogId", "CommentText", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Comment from DenisGuest", 2 },
                    { 2, 1, "Comment from DenisPrime", 3 }
                });

            migrationBuilder.InsertData(
                table: "BlogUserReviews",
                columns: new[] { "Id", "BlogId", "Grade", "UserId" },
                values: new object[,]
                {
                    { 1, 2, (short)0, 1 },
                    { 2, 3, (short)1, 1 },
                    { 3, 1, (short)1, 2 },
                    { 4, 3, (short)1, 2 },
                    { 5, 1, (short)0, 3 },
                    { 6, 2, (short)-1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Blogs_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "BlogUserBookmark_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "BlogUserComment_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "BlogUserReview_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "UserRoles_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "Users_Seq",
                schema: "public");

            migrationBuilder.DeleteData(
                table: "BlogUserBookmarks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogUserBookmarks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogUserBookmarks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogUserComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogUserReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogUserReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogUserReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogUserReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogUserReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogUserReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"Users_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"UserRoles_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogUserReviews",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"BlogUserReview_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogUserComments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"BlogUserComment_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogUserBookmarks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"BlogUserBookmark_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Blogs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"Blogs_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
