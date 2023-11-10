using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RubikBook.Database.Migrations
{
    public partial class newonline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e067dd1-10c2-4ee6-b3bd-4accacfa963f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("765a153e-cd59-4833-a6ef-61c9748ffd6f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("29d5c5d7-0ccb-41da-ba63-fe9d032965e5"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("56ed12b0-3ab3-4b62-8069-4169e007b8e4"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("66e91660-1e33-41c2-bcce-6b072f34209d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("02f7f0d7-241f-4b03-b75e-d6f1fe3418be"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("66e91660-1e33-41c2-bcce-6b072f34209d"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("56ed12b0-3ab3-4b62-8069-4169e007b8e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02f7f0d7-241f-4b03-b75e-d6f1fe3418be"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66e91660-1e33-41c2-bcce-6b072f34209d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("1e067dd1-10c2-4ee6-b3bd-4accacfa963f"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("29d5c5d7-0ccb-41da-ba63-fe9d032965e5"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("765a153e-cd59-4833-a6ef-61c9748ffd6f"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("29d5c5d7-0ccb-41da-ba63-fe9d032965e5"), 0 });
        }
    }
}
