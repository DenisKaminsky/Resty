﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Resty.Data;

#nullable disable

namespace Resty.Data.Migrations
{
    [DbContext(typeof(RestyDbContext))]
    [Migration("20221024193655_Updated models 2")]
    partial class Updatedmodels2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("Blogs_Seq", "public")
                .StartsAt(4L);

            modelBuilder.HasSequence<int>("BlogUserBookmark_Seq", "public")
                .StartsAt(4L);

            modelBuilder.HasSequence<int>("BlogUserComment_Seq", "public")
                .StartsAt(3L);

            modelBuilder.HasSequence<int>("BlogUserReview_Seq", "public")
                .StartsAt(7L);

            modelBuilder.HasSequence<int>("UserRoles_Seq", "public")
                .StartsAt(4L);

            modelBuilder.HasSequence<int>("Users_Seq", "public")
                .StartsAt(4L);

            modelBuilder.Entity("Resty.Data.Models.Blog.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"Blogs_Seq\"')");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CreatedDateUtc");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "TEST",
                            CreatedDateUtc = new DateTime(2022, 10, 24, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(3117),
                            Description = "Blog created by DenisAdmin",
                            Title = "DenisAdmin Blog"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "TEST 2",
                            CreatedDateUtc = new DateTime(2022, 10, 24, 18, 36, 55, 409, DateTimeKind.Utc).AddTicks(3119),
                            Description = "Blog created by DenisGuest",
                            Title = "DenisGuest Blog"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Content = "TEST 3",
                            CreatedDateUtc = new DateTime(2022, 10, 24, 17, 36, 55, 409, DateTimeKind.Utc).AddTicks(3120),
                            Title = "DenisPrime Blog"
                        });
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.BlogUserBookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"BlogUserBookmark_Seq\"')");

                    b.Property<int>("BlogId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId", "BlogId")
                        .IsUnique();

                    b.ToTable("BlogUserBookmarks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BlogId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.BlogUserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"BlogUserComment_Seq\"')");

                    b.Property<int>("BlogId")
                        .HasColumnType("integer");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId", "BlogId")
                        .IsUnique();

                    b.ToTable("BlogUserComments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 1,
                            CommentText = "Comment from DenisGuest",
                            CreatedDateUtc = new DateTime(2022, 10, 24, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(3294),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 1,
                            CommentText = "Comment from DenisPrime",
                            CreatedDateUtc = new DateTime(2022, 10, 24, 16, 36, 55, 409, DateTimeKind.Utc).AddTicks(3295),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.BlogUserReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"BlogUserReview_Seq\"')");

                    b.Property<int>("BlogId")
                        .HasColumnType("integer");

                    b.Property<short>("Grade")
                        .HasColumnType("smallint");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId", "BlogId")
                        .IsUnique();

                    b.ToTable("BlogUserReviews");

                    b.HasCheckConstraint("CK_BlogUserReview_Grade", "\"Grade\" >= -1 AND \"Grade\" <= 1");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 2,
                            Grade = (short)0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 3,
                            Grade = (short)1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BlogId = 1,
                            Grade = (short)1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            BlogId = 3,
                            Grade = (short)1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            BlogId = 1,
                            Grade = (short)0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 6,
                            BlogId = 2,
                            Grade = (short)-1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Resty.Data.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"Users_Seq\"')");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("EndDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Rating");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "deniskaminsky123@mail.ru",
                            FirstName = "Denis",
                            LastName = "Kaminsky",
                            PasswordHash = "21232f297a57a5a743894a0e4a801fc3",
                            Rating = 900,
                            RoleId = 1,
                            StartDateUtc = new DateTime(2022, 7, 16, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2946),
                            Username = "DenisAdmin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "deniskaminskyGuest@mail.ru",
                            FirstName = "Denis",
                            LastName = "KaminskyGuest",
                            PasswordHash = "21232f297a57a5a743894a0e4a801fc3",
                            Rating = 1,
                            RoleId = 2,
                            StartDateUtc = new DateTime(2022, 10, 14, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2950),
                            Username = "DenisGuest"
                        },
                        new
                        {
                            Id = 3,
                            Email = "deniskaminskyPrime@mail.ru",
                            FirstName = "Denis",
                            LastName = "KaminskyPrime",
                            PasswordHash = "21232f297a57a5a743894a0e4a801fc3",
                            Rating = 3,
                            RoleId = 3,
                            StartDateUtc = new DateTime(2022, 10, 19, 19, 36, 55, 409, DateTimeKind.Utc).AddTicks(2952),
                            Username = "DenisPrime"
                        });
                });

            modelBuilder.Entity("Resty.Data.Models.User.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"UserRoles_Seq\"')");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Type = "GuestUser"
                        },
                        new
                        {
                            Id = 3,
                            Type = "PrimeUser"
                        });
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.Blog", b =>
                {
                    b.HasOne("Resty.Data.Models.User.User", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.BlogUserBookmark", b =>
                {
                    b.HasOne("Resty.Data.Models.Blog.Blog", "Blog")
                        .WithMany("UserBookmarks")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resty.Data.Models.User.User", "User")
                        .WithMany("BlogBookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.BlogUserComment", b =>
                {
                    b.HasOne("Resty.Data.Models.Blog.Blog", "Blog")
                        .WithMany("UserComments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resty.Data.Models.User.User", "User")
                        .WithMany("BlogComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.BlogUserReview", b =>
                {
                    b.HasOne("Resty.Data.Models.Blog.Blog", "Blog")
                        .WithMany("UserReviews")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resty.Data.Models.User.User", "User")
                        .WithMany("BlogReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Resty.Data.Models.User.User", b =>
                {
                    b.HasOne("Resty.Data.Models.User.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Resty.Data.Models.Blog.Blog", b =>
                {
                    b.Navigation("UserBookmarks");

                    b.Navigation("UserComments");

                    b.Navigation("UserReviews");
                });

            modelBuilder.Entity("Resty.Data.Models.User.User", b =>
                {
                    b.Navigation("BlogBookmarks");

                    b.Navigation("BlogComments");

                    b.Navigation("BlogReviews");

                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("Resty.Data.Models.User.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
