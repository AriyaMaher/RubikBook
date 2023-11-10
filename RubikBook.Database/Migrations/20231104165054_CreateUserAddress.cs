using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RubikBook.Database.Migrations
{
    public partial class CreateUserAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

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

            migrationBuilder.RenameTable(
                name: "UserAddress",
                newName: "userAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_UserId",
                table: "userAddresses",
                newName: "IX_userAddresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAddresses",
                table: "userAddresses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("2ef49cd5-d08d-48b4-b5c0-646ce8b6243c"), "user", "کاربر" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("f47594f2-4f5f-460d-be22-ce7fbac24d10"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Mobile", "Password", "RoleId", "code" },
                values: new object[] { new Guid("3829279a-cdc7-4c98-beb7-f8c3fbc44cfa"), true, "09115523293", "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD", new Guid("f47594f2-4f5f-460d-be22-ce7fbac24d10"), 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_userAddresses_Users_UserId",
                table: "userAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAddresses_Users_UserId",
                table: "userAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAddresses",
                table: "userAddresses");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2ef49cd5-d08d-48b4-b5c0-646ce8b6243c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3829279a-cdc7-4c98-beb7-f8c3fbc44cfa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f47594f2-4f5f-460d-be22-ce7fbac24d10"));

            migrationBuilder.RenameTable(
                name: "userAddresses",
                newName: "UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_userAddresses_UserId",
                table: "UserAddress",
                newName: "IX_UserAddress_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
