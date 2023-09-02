using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RubikBook.Database.Migrations
{
    public partial class CreatDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeCategoryName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AuthorDes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GroupDes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    TotalPages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeCategoryId = table.Column<int>(type: "int", nullable: false),
                    Des = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    SellOff = table.Column<int>(type: "int", nullable: false),
                    NotShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AgeCategorys_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AgeCategorys",
                columns: new[] { "Id", "AgeCategoryName", "NotShow" },
                values: new object[,]
                {
                    { 1, "کودک", false },
                    { 2, "نوجوان", false },
                    { 3, "جوان", false },
                    { 4, "بزرگسال", false }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorDes", "AuthorName", "NotShow" },
                values: new object[] { 1, null, "جورج اورول", false });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupDes", "GroupName", "NotShow" },
                values: new object[,]
                {
                    { 1, null, "فلسفه و روانشناسی", false },
                    { 2, null, "تاریخ و جغرافیا", false },
                    { 3, null, "رمان و داستان", false },
                    { 4, null, "کتاب صوتی", false }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "NotShow", "PublisherName" },
                values: new object[] { 1, false, "پرتقال" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("04b4dd41-cbdf-4fe0-8b8a-f68387c34c9f"), "user", "کاربر" },
                    { new Guid("b2bc7663-4602-4440-832f-fb856de1d3c9"), "admin", "مدیر" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("7becd03c-d0a5-4914-b7f5-4dfbcdfe3bf6"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("b2bc7663-4602-4440-832f-fb856de1d3c9"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AgeCategoryId",
                table: "Products",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorId",
                table: "Products",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PublisherId",
                table: "Products",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AgeCategorys");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
