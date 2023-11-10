using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RubikBook.Database.Migrations
{
    public partial class deleteageCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AgeCategorys_AgeCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "AgeCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Products_AgeCategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("312496ec-e02a-4fc9-ae6a-40d9631e8d74"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4272274-f51f-40dc-9a9c-c5e62632e25e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9a060466-e0c5-4788-87b1-2e10c5838a73"));

            migrationBuilder.DropColumn(
                name: "AgeCategoryId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("637fffd4-1beb-4602-81d9-3afd7815cf22"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9bb8217b-c6b1-4797-8254-7f2464745f3a"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("e6651a3e-7ad7-42ce-ba7d-1fc10fa5b603"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("637fffd4-1beb-4602-81d9-3afd7815cf22"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9bb8217b-c6b1-4797-8254-7f2464745f3a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6651a3e-7ad7-42ce-ba7d-1fc10fa5b603"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("637fffd4-1beb-4602-81d9-3afd7815cf22"));

            migrationBuilder.AddColumn<int>(
                name: "AgeCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "Publishers",
                columns: new[] { "Id", "NotShow", "PublisherName" },
                values: new object[] { 1, false, "پرتقال" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("312496ec-e02a-4fc9-ae6a-40d9631e8d74"), "user", "کاربر" },
                    { new Guid("9a060466-e0c5-4788-87b1-2e10c5838a73"), "admin", "مدیر" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("f4272274-f51f-40dc-9a9c-c5e62632e25e"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("9a060466-e0c5-4788-87b1-2e10c5838a73"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AgeCategoryId",
                table: "Products",
                column: "AgeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AgeCategorys_AgeCategoryId",
                table: "Products",
                column: "AgeCategoryId",
                principalTable: "AgeCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
