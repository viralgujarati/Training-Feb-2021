using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotstar_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        CategoryId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CategoryName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.CategoryId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Plan",
            //    columns: table => new
            //    {
            //        PlanID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PlanCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Plan", x => x.PlanID);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "UserAccount",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        PhoneNumber = table.Column<int>(type: "int", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        DOB = table.Column<DateTime>(type: "date", nullable: true),
            //        ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__UserAcco__A4AE64B80FA68D9F", x => x.CustomerID);
            //        table.ForeignKey(
            //            name: "FK_UserAccount_AspNetUsers_ApplicationUserId",
            //            column: x => x.ApplicationUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubCategories",
            //    columns: table => new
            //    {
            //        SubCategoryId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SubCategoryName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        ParentCategoryId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubCategories", x => x.SubCategoryId);
            //        table.ForeignKey(
            //            name: "FK__SubCatego__Paren__2A4B4B5E",
            //            column: x => x.ParentCategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "CategoryId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubcriptionPriceList",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PlanId = table.Column<int>(type: "int", nullable: true),
            //        Validity = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Price = table.Column<decimal>(type: "money", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubcriptionPriceList", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Subcripti__PlanI__2F10007B",
            //            column: x => x.PlanId,
            //            principalTable: "Plan",
            //            principalColumn: "PlanID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Content",
            //    columns: table => new
            //    {
            //        ContentId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ContentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ContentPosterLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Genre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        SuitableAge = table.Column<int>(type: "int", nullable: true),
            //        SubCategoryId = table.Column<int>(type: "int", nullable: true),
            //        CategoryId = table.Column<int>(type: "int", nullable: false),
            //        PlanId = table.Column<int>(type: "int", nullable: true),
            //        ContentLanguage = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Content", x => x.ContentId);
            //        table.ForeignKey(
            //            name: "FK__Content__Categor__32E0915F",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "CategoryId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Content__PlanId__33D4B598",
            //            column: x => x.PlanId,
            //            principalTable: "Plan",
            //            principalColumn: "PlanID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Content__SubCate__31EC6D26",
            //            column: x => x.SubCategoryId,
            //            principalTable: "SubCategories",
            //            principalColumn: "SubCategoryId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubscriptionDetail",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerID = table.Column<int>(type: "int", nullable: false),
            //        PlanID = table.Column<int>(type: "int", nullable: false),
            //        SubcriptionPriceListId = table.Column<int>(type: "int", nullable: true),
            //        DateOfSubscription = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ValidThrough = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubscriptionDetail", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Subscript__Custo__36B12243",
            //            column: x => x.CustomerID,
            //            principalTable: "UserAccount",
            //            principalColumn: "CustomerID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Subscript__PlanI__37A5467C",
            //            column: x => x.PlanID,
            //            principalTable: "Plan",
            //            principalColumn: "PlanID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Subscript__Subcr__38996AB5",
            //            column: x => x.SubcriptionPriceListId,
            //            principalTable: "SubcriptionPriceList",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Shows",
            //    columns: table => new
            //    {
            //        ShowID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ShowName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Episode = table.Column<int>(type: "int", nullable: true),
            //        Season = table.Column<int>(type: "int", nullable: true),
            //        ContentId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Shows", x => x.ShowID);
            //        table.ForeignKey(
            //            name: "FK__Shows__ContentId__3B75D760",
            //            column: x => x.ContentId,
            //            principalTable: "Content",
            //            principalColumn: "ContentId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Content_CategoryId",
            //    table: "Content",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Content_PlanId",
            //    table: "Content",
            //    column: "PlanId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Content_SubCategoryId",
            //    table: "Content",
            //    column: "SubCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Shows_ContentId",
            //    table: "Shows",
            //    column: "ContentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubCategories_ParentCategoryId",
            //    table: "SubCategories",
            //    column: "ParentCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubcriptionPriceList_PlanId",
            //    table: "SubcriptionPriceList",
            //    column: "PlanId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubscriptionDetail_CustomerID",
            //    table: "SubscriptionDetail",
            //    column: "CustomerID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubscriptionDetail_PlanID",
            //    table: "SubscriptionDetail",
            //    column: "PlanID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubscriptionDetail_SubcriptionPriceListId",
            //    table: "SubscriptionDetail",
            //    column: "SubcriptionPriceListId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserAccount_ApplicationUserId",
            //    table: "UserAccount",
            //    column: "ApplicationUserId",
            //    unique: true,
            //    filter: "[ApplicationUserId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__UserAcco__A9D10534AF370B1F",
            //    table: "UserAccount",
            //    column: "Email",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Shows");

            //migrationBuilder.DropTable(
            //    name: "SubscriptionDetail");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "Content");

            //migrationBuilder.DropTable(
            //    name: "UserAccount");

            //migrationBuilder.DropTable(
            //    name: "SubcriptionPriceList");

            //migrationBuilder.DropTable(
            //    name: "SubCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Plan");

            //migrationBuilder.DropTable(
            //    name: "Categories");
        }
    }
}
