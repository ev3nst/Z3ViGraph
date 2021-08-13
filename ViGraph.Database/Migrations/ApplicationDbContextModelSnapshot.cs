﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViGraph.Database;

namespace ViGraph.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ViGraph.Models.AppFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Folder")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Mime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("enum('Initialized','Paused', 'Completed', 'Failed')");

                    b.Property<int>("TotalSize")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UploadedSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppFile");
                });

            modelBuilder.Entity("ViGraph.Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Sef")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "10924c6f-a7c5-4b54-b779-c4c955329599",
                            Name = "Super Admin",
                            Sef = "super-admin"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "cd83171c-1c00-4df0-a375-a6e98d4e5ccd",
                            Name = "Admin",
                            Sef = "admin"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "918d5ece-4547-4626-9d26-183eb9c40e9e",
                            Name = "Editor",
                            Sef = "editor"
                        });
                });

            modelBuilder.Entity("ViGraph.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("DeletedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("enum('TR','EN')");

                    b.Property<DateTime?>("LastLogin")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("LastLogin");

                    b.Property<string>("LastLoginIP")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastLogout")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("LastLogout");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("LockoutEnd");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "z3@vigraph.com",
                            FullName = "Z3 Root",
                            Language = "TR",
                            LockoutEnabled = false,
                            NormalizedUserName = "z3@vigraph.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEO/8ULenhRdQk8vJeYX4M1jb9n7xvLhaOh7RKkUHLohVrGcE9idg3vPQfa6+AQmwnQ==",
                            UserName = "z3@vigraph.com"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test@admin.com",
                            FullName = "Test Admin",
                            Language = "TR",
                            LockoutEnabled = false,
                            NormalizedUserName = "test@admin.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEDfCgpxMBSpTUF/5o6N4U6gAPmN02z3dOdNY8sWfsCeaWDcNEEWOLx+LV9nkAqTpCA==",
                            UserName = "test@admin.com"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test@editor.com",
                            FullName = "Test Editor",
                            Language = "TR",
                            LockoutEnabled = false,
                            NormalizedUserName = "test@editor.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAmeo1HjATu9dXhEscR0ix4cfKKGXeaKYii2vtjYk/DiUkWkP0DxfPIW9A7eDFe9oA==",
                            UserName = "test@editor.com"
                        });
                });

            modelBuilder.Entity("ViGraph.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("DeletedAt");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Sef")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 13, 16, 38, 38, 516, DateTimeKind.Local).AddTicks(4960),
                            CreatedById = 1,
                            Sef = "gundem",
                            Title = "Gündem"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 8, 13, 16, 38, 38, 516, DateTimeKind.Local).AddTicks(6650),
                            CreatedById = 1,
                            Sef = "spor",
                            Title = "Spor"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 8, 13, 16, 38, 38, 516, DateTimeKind.Local).AddTicks(6650),
                            CreatedById = 1,
                            Sef = "yasam",
                            Title = "Yaşam"
                        });
                });

            modelBuilder.Entity("ViGraph.Models.Thumbnail", b =>
                {
                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("enum('default','medium', 'high', 'standart', 'maxres')");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasIndex("CreatedById");

                    b.HasIndex("VideoId");

                    b.HasIndex("FileId", "VideoId", "Size")
                        .IsUnique();

                    b.ToTable("Thumbnails");
                });

            modelBuilder.Entity("ViGraph.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("DeletedAt");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("HDFileId")
                        .HasColumnType("int");

                    b.Property<int>("SDFileId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<string>("UploadStatus")
                        .IsRequired()
                        .HasColumnType("enum('initialized', 'started', 'deleted','failed', 'processed', 'rejected', 'uploaded')");

                    b.Property<int>("YTCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("YTMetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("HDFileId");

                    b.HasIndex("SDFileId");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("YTCategoryId");

                    b.HasIndex("YTMetaId")
                        .IsUnique();

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ViGraph.Models.VideoViewCount", b =>
                {
                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasMaxLength(2147483647)
                        .HasColumnType("int");

                    b.HasIndex("VideoId")
                        .IsUnique();

                    b.ToTable("VideoViewCounts");
                });

            modelBuilder.Entity("ViGraph.Models.YTCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Assignable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Etag")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("YTChannelId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("YTId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("YTId")
                        .IsUnique();

                    b.ToTable("YTCategories");
                });

            modelBuilder.Entity("ViGraph.Models.YTChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("About")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Etag")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Keywords")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("YTId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("YTId")
                        .IsUnique();

                    b.ToTable("YTChannels");
                });

            modelBuilder.Entity("ViGraph.Models.YTMeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DefaultLanguage")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Etag")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PrivacyStatus")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("PublicStatsViewable")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("PublishedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("PublishedAt");

                    b.Property<string>("YTChannelId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("YTId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("YTId")
                        .IsUnique();

                    b.ToTable("YTMetas");
                });

            modelBuilder.Entity("ViGraph.Models.YTPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Etag")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<string>("YTChannelId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("YTId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("YTMetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("YTId")
                        .IsUnique();

                    b.HasIndex("YTMetaId")
                        .IsUnique();

                    b.ToTable("YTPlaylists");
                });

            modelBuilder.Entity("ViGraph.Models.YTPlaylistItem", b =>
                {
                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<int>("YTPlaylistId")
                        .HasColumnType("int");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("YTPlaylistId", "Position")
                        .IsUnique();

                    b.ToTable("YTPlaylistItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ViGraph.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ViGraph.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ViGraph.Models.Category", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("ViGraph.Models.Thumbnail", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("File");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("ViGraph.Models.Video", b =>
                {
                    b.HasOne("ViGraph.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppFile", "HDFile")
                        .WithMany()
                        .HasForeignKey("HDFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppFile", "SDFile")
                        .WithMany()
                        .HasForeignKey("SDFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.HasOne("ViGraph.Models.YTCategory", "YTCategory")
                        .WithMany()
                        .HasForeignKey("YTCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.YTMeta", "YTMeta")
                        .WithMany()
                        .HasForeignKey("YTMetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("HDFile");

                    b.Navigation("SDFile");

                    b.Navigation("UpdatedBy");

                    b.Navigation("YTCategory");

                    b.Navigation("YTMeta");
                });

            modelBuilder.Entity("ViGraph.Models.VideoViewCount", b =>
                {
                    b.HasOne("ViGraph.Models.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("ViGraph.Models.YTPlaylist", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.HasOne("ViGraph.Models.YTMeta", "YTMeta")
                        .WithMany()
                        .HasForeignKey("YTMetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");

                    b.Navigation("YTMeta");
                });

            modelBuilder.Entity("ViGraph.Models.YTPlaylistItem", b =>
                {
                    b.HasOne("ViGraph.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViGraph.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.HasOne("ViGraph.Models.YTPlaylist", "YTPlaylist")
                        .WithMany()
                        .HasForeignKey("YTPlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");

                    b.Navigation("YTPlaylist");
                });
#pragma warning restore 612, 618
        }
    }
}
