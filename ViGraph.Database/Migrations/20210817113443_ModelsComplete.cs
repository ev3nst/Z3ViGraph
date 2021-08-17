using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViGraph.Database.Migrations
{
    public partial class ModelsComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Folder = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mime = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalSize = table.Column<int>(type: "int", nullable: false),
                    UploadedSize = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "enum('Initialized','Paused', 'Completed', 'Failed')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFile", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sef = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Language = table.Column<string>(type: "enum('TR','EN')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLogin = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    LastLoginIP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLogout = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(0)", precision: 0, nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "YTCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Assignable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Etag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTChannelId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "YTChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Keywords = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    About = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Etag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTChannels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "YTMetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrivacyStatus = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    DefaultLanguage = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublicStatsViewable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Etag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTChannelId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTMetas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sef = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "YTPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTMetaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    Etag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YTChannelId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YTPlaylists_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YTPlaylists_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YTPlaylists_YTMetas_YTMetaId",
                        column: x => x.YTMetaId,
                        principalTable: "YTMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HDFileId = table.Column<int>(type: "int", nullable: false),
                    SDFileId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tags = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    YTMetaId = table.Column<int>(type: "int", nullable: false),
                    YTCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UploadStatus = table.Column<string>(type: "enum('initialized', 'started', 'deleted','failed', 'processed', 'rejected', 'uploaded')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_AppFile_HDFileId",
                        column: x => x.HDFileId,
                        principalTable: "AppFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_AppFile_SDFileId",
                        column: x => x.SDFileId,
                        principalTable: "AppFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_YTCategories_YTCategoryId",
                        column: x => x.YTCategoryId,
                        principalTable: "YTCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_YTMetas_YTMetaId",
                        column: x => x.YTMetaId,
                        principalTable: "YTMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "YTPlaylistItems",
                columns: table => new
                {
                    YTPlaylistId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_YTPlaylistItems_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YTPlaylistItems_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YTPlaylistItems_YTPlaylists_YTPlaylistId",
                        column: x => x.YTPlaylistId,
                        principalTable: "YTPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Thumbnails",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "enum('default','medium', 'high', 'standart', 'maxres')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", precision: 0, nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Thumbnails_AppFile_FileId",
                        column: x => x.FileId,
                        principalTable: "AppFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thumbnails_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thumbnails_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VideoViewCounts",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_VideoViewCounts_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Sef" },
                values: new object[,]
                {
                    { 1, "4c84bf06-61e4-4de1-b9a9-e5ca1da12e06", null, "Super Admin", "SuperAdmin", "super-admin" },
                    { 2, "3da526de-e35c-4d4b-8dff-107029d8d40d", null, "Admin", "Admin", "admin" },
                    { 3, "46305bd9-467c-49e6-9d59-cf06bd97b922", null, "Editor", "Editor", "editor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FullName", "Language", "LastLogin", "LastLoginIP", "LastLogout", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "z3@vigraph.com", "Z3 Root", "TR", null, null, null, false, null, "z3@vigraph.com", "z3@vigraph.com", "AQAAAAEAACcQAAAAECoeTh0aBqiDqLJ4RTlOAleyX3w+kjok/l/2fe57iuEWS/P6HPgrBKuUB6ac6uaa/g==", "95f2f7df-eb99-44c7-9173-e11436b7d03c", null, "z3@vigraph.com" },
                    { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "test@admin.com", "Test Admin", "TR", null, null, null, false, null, "test@admin.com", "test@admin.com", "AQAAAAEAACcQAAAAEGUOIJ4OShydndCOlER4mLcBV8ApTd6Zo8JNDqqCVwlYnfCo905rLUapcjnc5SWIew==", "e8e63224-f5b2-4d95-8aa9-f8df99fd26d0", null, "test@admin.com" },
                    { 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "test@editor.com", "Test Editor", "TR", null, null, null, false, null, "test@editor.com", "test@editor.com", "AQAAAAEAACcQAAAAENFiFkjTNZ3oM73nKcd9f6/MNLjoAoaCpDuD2imEmvvKLv1FYsGHnvaxDPnGER6/ZA==", "86be72dc-5c04-45b4-90d2-2783c35e3895", null, "test@editor.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DeletedAt", "Description", "Sef", "Title", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 8, 17, 14, 34, 42, 725, DateTimeKind.Local).AddTicks(2920), 1, null, null, "yasam", "Yaşam", null, null },
                    { 2, new DateTime(2021, 8, 17, 14, 34, 42, 725, DateTimeKind.Local).AddTicks(2910), 1, null, null, "spor", "Spor", null, null },
                    { 1, new DateTime(2021, 8, 17, 14, 34, 42, 725, DateTimeKind.Local).AddTicks(1260), 1, null, null, "gundem", "Gündem", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "AppFile.Create", 1 },
                    { 158, "Permission", "YTPlaylistItem.Create", 2 },
                    { 161, "Permission", "YTPlaylistItem.View", 2 },
                    { 164, "Permission", "YTPlaylistItem.Edit", 2 },
                    { 167, "Permission", "YTPlaylistItem.Delete", 2 },
                    { 170, "Permission", "YTPlaylistItem.Restore", 2 },
                    { 173, "Permission", "YTPlaylistItem.ForceDelete", 2 },
                    { 3, "Permission", "AppFile.Create", 3 },
                    { 6, "Permission", "AppFile.View", 3 },
                    { 12, "Permission", "AppFile.Delete", 3 },
                    { 155, "Permission", "YTPlaylist.ForceDelete", 2 },
                    { 15, "Permission", "AppFile.Restore", 3 },
                    { 18, "Permission", "AppFile.ForceDelete", 3 },
                    { 33, "Permission", "Category.Create", 3 },
                    { 36, "Permission", "Category.View", 3 },
                    { 39, "Permission", "Category.Edit", 3 },
                    { 42, "Permission", "Category.Delete", 3 },
                    { 45, "Permission", "Category.Restore", 3 },
                    { 9, "Permission", "AppFile.Edit", 3 },
                    { 152, "Permission", "YTPlaylist.Restore", 2 },
                    { 146, "Permission", "YTPlaylist.Edit", 2 },
                    { 48, "Permission", "Category.ForceDelete", 3 },
                    { 92, "Permission", "YTCategory.Edit", 2 },
                    { 95, "Permission", "YTCategory.Delete", 2 },
                    { 98, "Permission", "YTCategory.Restore", 2 },
                    { 101, "Permission", "YTCategory.ForceDelete", 2 },
                    { 104, "Permission", "YTChannel.Create", 2 },
                    { 107, "Permission", "YTChannel.View", 2 },
                    { 110, "Permission", "YTChannel.Edit", 2 },
                    { 113, "Permission", "YTChannel.Delete", 2 },
                    { 149, "Permission", "YTPlaylist.Delete", 2 },
                    { 116, "Permission", "YTChannel.Restore", 2 },
                    { 122, "Permission", "YTMeta.Create", 2 },
                    { 125, "Permission", "YTMeta.View", 2 },
                    { 128, "Permission", "YTMeta.Edit", 2 },
                    { 131, "Permission", "YTMeta.Delete", 2 },
                    { 134, "Permission", "YTMeta.Restore", 2 },
                    { 137, "Permission", "YTMeta.ForceDelete", 2 },
                    { 140, "Permission", "YTPlaylist.Create", 2 },
                    { 143, "Permission", "YTPlaylist.View", 2 },
                    { 119, "Permission", "YTChannel.ForceDelete", 2 },
                    { 51, "Permission", "Video.Create", 3 },
                    { 57, "Permission", "Video.Edit", 3 },
                    { 89, "Permission", "YTCategory.View", 2 },
                    { 126, "Permission", "YTMeta.View", 3 },
                    { 129, "Permission", "YTMeta.Edit", 3 },
                    { 132, "Permission", "YTMeta.Delete", 3 },
                    { 135, "Permission", "YTMeta.Restore", 3 },
                    { 138, "Permission", "YTMeta.ForceDelete", 3 },
                    { 141, "Permission", "YTPlaylist.Create", 3 },
                    { 144, "Permission", "YTPlaylist.View", 3 },
                    { 147, "Permission", "YTPlaylist.Edit", 3 },
                    { 150, "Permission", "YTPlaylist.Delete", 3 },
                    { 153, "Permission", "YTPlaylist.Restore", 3 },
                    { 156, "Permission", "YTPlaylist.ForceDelete", 3 },
                    { 159, "Permission", "YTPlaylistItem.Create", 3 },
                    { 162, "Permission", "YTPlaylistItem.View", 3 },
                    { 165, "Permission", "YTPlaylistItem.Edit", 3 },
                    { 168, "Permission", "YTPlaylistItem.Delete", 3 },
                    { 171, "Permission", "YTPlaylistItem.Restore", 3 },
                    { 174, "Permission", "YTPlaylistItem.ForceDelete", 3 },
                    { 123, "Permission", "YTMeta.Create", 3 },
                    { 120, "Permission", "YTChannel.ForceDelete", 3 },
                    { 117, "Permission", "YTChannel.Restore", 3 },
                    { 114, "Permission", "YTChannel.Delete", 3 },
                    { 60, "Permission", "Video.Delete", 3 },
                    { 63, "Permission", "Video.Restore", 3 },
                    { 66, "Permission", "Video.ForceDelete", 3 },
                    { 69, "Permission", "VideoViewCount.Create", 3 },
                    { 72, "Permission", "VideoViewCount.View", 3 },
                    { 75, "Permission", "VideoViewCount.Edit", 3 },
                    { 78, "Permission", "VideoViewCount.Delete", 3 },
                    { 81, "Permission", "VideoViewCount.Restore", 3 },
                    { 54, "Permission", "Video.View", 3 },
                    { 84, "Permission", "VideoViewCount.ForceDelete", 3 },
                    { 90, "Permission", "YTCategory.View", 3 },
                    { 93, "Permission", "YTCategory.Edit", 3 },
                    { 96, "Permission", "YTCategory.Delete", 3 },
                    { 99, "Permission", "YTCategory.Restore", 3 },
                    { 102, "Permission", "YTCategory.ForceDelete", 3 },
                    { 105, "Permission", "YTChannel.Create", 3 },
                    { 108, "Permission", "YTChannel.View", 3 },
                    { 111, "Permission", "YTChannel.Edit", 3 },
                    { 87, "Permission", "YTCategory.Create", 3 },
                    { 86, "Permission", "YTCategory.Create", 2 },
                    { 83, "Permission", "VideoViewCount.ForceDelete", 2 },
                    { 106, "Permission", "YTChannel.View", 1 },
                    { 52, "Permission", "Video.View", 1 },
                    { 55, "Permission", "Video.Edit", 1 },
                    { 58, "Permission", "Video.Delete", 1 },
                    { 61, "Permission", "Video.Restore", 1 },
                    { 64, "Permission", "Video.ForceDelete", 1 },
                    { 67, "Permission", "VideoViewCount.Create", 1 },
                    { 70, "Permission", "VideoViewCount.View", 1 },
                    { 73, "Permission", "VideoViewCount.Edit", 1 },
                    { 49, "Permission", "Video.Create", 1 },
                    { 76, "Permission", "VideoViewCount.Delete", 1 },
                    { 82, "Permission", "VideoViewCount.ForceDelete", 1 },
                    { 85, "Permission", "YTCategory.Create", 1 },
                    { 88, "Permission", "YTCategory.View", 1 },
                    { 91, "Permission", "YTCategory.Edit", 1 },
                    { 94, "Permission", "YTCategory.Delete", 1 },
                    { 97, "Permission", "YTCategory.Restore", 1 },
                    { 100, "Permission", "YTCategory.ForceDelete", 1 },
                    { 103, "Permission", "YTChannel.Create", 1 },
                    { 79, "Permission", "VideoViewCount.Restore", 1 },
                    { 80, "Permission", "VideoViewCount.Restore", 2 },
                    { 46, "Permission", "Category.ForceDelete", 1 },
                    { 40, "Permission", "Category.Delete", 1 },
                    { 4, "Permission", "AppFile.View", 1 },
                    { 13, "Permission", "AppFile.Restore", 1 },
                    { 16, "Permission", "AppFile.ForceDelete", 1 },
                    { 19, "Permission", "AppRole.Create", 1 },
                    { 20, "Permission", "AppRole.View", 1 },
                    { 21, "Permission", "AppRole.Edit", 1 },
                    { 22, "Permission", "AppRole.Delete", 1 },
                    { 23, "Permission", "AppRole.Restore", 1 },
                    { 43, "Permission", "Category.Restore", 1 },
                    { 24, "Permission", "AppRole.ForceDelete", 1 },
                    { 26, "Permission", "AppUser.View", 1 },
                    { 27, "Permission", "AppUser.Edit", 1 },
                    { 28, "Permission", "AppUser.Delete", 1 },
                    { 29, "Permission", "AppUser.Restore", 1 },
                    { 30, "Permission", "AppUser.ForceDelete", 1 },
                    { 31, "Permission", "Category.Create", 1 },
                    { 34, "Permission", "Category.View", 1 },
                    { 37, "Permission", "Category.Edit", 1 },
                    { 25, "Permission", "AppUser.Create", 1 },
                    { 109, "Permission", "YTChannel.Edit", 1 },
                    { 112, "Permission", "YTChannel.Delete", 1 },
                    { 115, "Permission", "YTChannel.Restore", 1 },
                    { 14, "Permission", "AppFile.Restore", 2 },
                    { 17, "Permission", "AppFile.ForceDelete", 2 },
                    { 32, "Permission", "Category.Create", 2 },
                    { 35, "Permission", "Category.View", 2 },
                    { 38, "Permission", "Category.Edit", 2 },
                    { 41, "Permission", "Category.Delete", 2 },
                    { 44, "Permission", "Category.Restore", 2 },
                    { 47, "Permission", "Category.ForceDelete", 2 },
                    { 11, "Permission", "AppFile.Delete", 2 },
                    { 50, "Permission", "Video.Create", 2 },
                    { 56, "Permission", "Video.Edit", 2 },
                    { 59, "Permission", "Video.Delete", 2 },
                    { 62, "Permission", "Video.Restore", 2 },
                    { 65, "Permission", "Video.ForceDelete", 2 },
                    { 68, "Permission", "VideoViewCount.Create", 2 },
                    { 71, "Permission", "VideoViewCount.View", 2 },
                    { 74, "Permission", "VideoViewCount.Edit", 2 },
                    { 77, "Permission", "VideoViewCount.Delete", 2 },
                    { 53, "Permission", "Video.View", 2 },
                    { 8, "Permission", "AppFile.Edit", 2 },
                    { 5, "Permission", "AppFile.View", 2 },
                    { 2, "Permission", "AppFile.Create", 2 },
                    { 118, "Permission", "YTChannel.ForceDelete", 1 },
                    { 121, "Permission", "YTMeta.Create", 1 },
                    { 124, "Permission", "YTMeta.View", 1 },
                    { 127, "Permission", "YTMeta.Edit", 1 },
                    { 130, "Permission", "YTMeta.Delete", 1 },
                    { 133, "Permission", "YTMeta.Restore", 1 },
                    { 136, "Permission", "YTMeta.ForceDelete", 1 },
                    { 139, "Permission", "YTPlaylist.Create", 1 },
                    { 142, "Permission", "YTPlaylist.View", 1 },
                    { 145, "Permission", "YTPlaylist.Edit", 1 },
                    { 148, "Permission", "YTPlaylist.Delete", 1 },
                    { 151, "Permission", "YTPlaylist.Restore", 1 },
                    { 154, "Permission", "YTPlaylist.ForceDelete", 1 },
                    { 157, "Permission", "YTPlaylistItem.Create", 1 },
                    { 160, "Permission", "YTPlaylistItem.View", 1 },
                    { 163, "Permission", "YTPlaylistItem.Edit", 1 },
                    { 166, "Permission", "YTPlaylistItem.Delete", 1 },
                    { 169, "Permission", "YTPlaylistItem.Restore", 1 },
                    { 172, "Permission", "YTPlaylistItem.ForceDelete", 1 },
                    { 10, "Permission", "AppFile.Delete", 1 },
                    { 7, "Permission", "AppFile.Edit", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 1, 1 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_CreatedById",
                table: "Thumbnails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_FileId_VideoId_Size",
                table: "Thumbnails",
                columns: new[] { "FileId", "VideoId", "Size" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_VideoId",
                table: "Thumbnails",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NormalizedEmail",
                table: "Users",
                column: "NormalizedEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CategoryId",
                table: "Videos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CreatedById",
                table: "Videos",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_HDFileId",
                table: "Videos",
                column: "HDFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_SDFileId",
                table: "Videos",
                column: "SDFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UpdatedById",
                table: "Videos",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_YTCategoryId",
                table: "Videos",
                column: "YTCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_YTMetaId",
                table: "Videos",
                column: "YTMetaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoViewCounts_VideoId",
                table: "VideoViewCounts",
                column: "VideoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YTCategories_YTId",
                table: "YTCategories",
                column: "YTId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YTChannels_YTId",
                table: "YTChannels",
                column: "YTId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YTMetas_YTId",
                table: "YTMetas",
                column: "YTId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylistItems_CreatedById",
                table: "YTPlaylistItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylistItems_UpdatedById",
                table: "YTPlaylistItems",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylistItems_YTPlaylistId_Position",
                table: "YTPlaylistItems",
                columns: new[] { "YTPlaylistId", "Position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylists_CreatedById",
                table: "YTPlaylists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylists_UpdatedById",
                table: "YTPlaylists",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylists_YTId",
                table: "YTPlaylists",
                column: "YTId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YTPlaylists_YTMetaId",
                table: "YTPlaylists",
                column: "YTMetaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Thumbnails");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VideoViewCounts");

            migrationBuilder.DropTable(
                name: "YTChannels");

            migrationBuilder.DropTable(
                name: "YTPlaylistItems");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "YTPlaylists");

            migrationBuilder.DropTable(
                name: "AppFile");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "YTCategories");

            migrationBuilder.DropTable(
                name: "YTMetas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
