using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RubikBook.Database.Migrations
{
    public partial class newtest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d7ad81f8-f208-44e3-8c17-6c50eae61069"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f9280db-f5ba-47e1-b83e-e3b7f4830d3c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8fe51653-0a6f-4a77-abf0-a679da424b2e"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("8fe51653-0a6f-4a77-abf0-a679da424b2e"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("d7ad81f8-f208-44e3-8c17-6c50eae61069"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("9f9280db-f5ba-47e1-b83e-e3b7f4830d3c"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("8fe51653-0a6f-4a77-abf0-a679da424b2e"), 0 });
        }
    }
}
