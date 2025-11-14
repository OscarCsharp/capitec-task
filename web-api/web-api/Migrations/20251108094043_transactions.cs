using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class transactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e186cf2-12e7-4d3e-b8bd-ff5d5aad9132", "b2f605c6-07c7-47fe-a443-22eddf538c7d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7388eaf1-b867-43ab-bba4-dd7bb4bff22d", "f2f944d7-44db-4213-8395-7bed7a42db69" });

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: "6a71b3ce-ad5b-4ff8-9e77-17b4f1202ca2");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: "7eba0399-3a20-4e0b-b8e6-f781574c460f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e186cf2-12e7-4d3e-b8bd-ff5d5aad9132");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7388eaf1-b867-43ab-bba4-dd7bb4bff22d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2f605c6-07c7-47fe-a443-22eddf538c7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2f944d7-44db-4213-8395-7bed7a42db69");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "referenceNumber");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45b48315-64e1-4aea-ba43-1267476e0bea", true, null, "Role", "user", "USER" },
                    { "781f8f7f-1119-4bfe-a535-8fec3de78bf4", true, null, "Role", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Deactivated", "Discriminator", "Email", "EmailAddress", "EmailConfirmed", "FirstName", "HashedPassword", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaltPassword", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "38c90fde-a178-4660-b2bc-bc258a4ee4d5", 0, "bfe995f7-4037-45dc-854a-bdd6370fa199", false, "User", null, "", false, "", new byte[] { 104, 219, 245, 164, 247, 186, 131, 192, 204, 142, 8, 155, 43, 91, 193, 118, 231, 158, 225, 180, 176, 18, 37, 76, 47, 38, 58, 128, 40, 195, 149, 212, 162, 210, 118, 80, 63, 101, 243, 237, 24, 72, 43, 26, 85, 68, 119, 25, 110, 43, 51, 75, 136, 55, 79, 15, 202, 102, 184, 79, 103, 151, 184, 237 }, "", false, null, null, "ADMIN", null, null, false, new byte[] { 43, 36, 16, 185, 26, 6, 248, 26, 52, 37, 138, 118, 157, 183, 144, 226, 148, 190, 5, 33, 185, 127, 236, 189, 129, 191, 159, 5, 133, 77, 162, 96, 120, 177, 225, 217, 192, 187, 43, 193, 152, 23, 132, 181, 29, 145, 40, 213, 225, 89, 29, 178, 130, 52, 212, 33, 52, 9, 203, 132, 17, 28, 151, 48, 22, 51, 116, 126, 141, 29, 241, 0, 75, 36, 83, 28, 0, 67, 190, 233, 250, 166, 30, 219, 249, 104, 226, 185, 243, 52, 67, 220, 174, 50, 41, 11, 16, 48, 220, 43, 79, 207, 22, 238, 180, 161, 109, 182, 252, 122, 121, 29, 1, 34, 42, 240, 204, 121, 147, 205, 195, 99, 175, 158, 133, 123, 230, 234 }, "119dc105-2a35-401a-8b42-977f0ae46885", false, "admin" },
                    { "adf4cb12-d93b-406d-baf5-45925ef35cf9", 0, "8e1acbb4-9801-4102-939c-86ad588f5626", false, "User", null, "", false, "", new byte[] { 148, 43, 43, 219, 107, 56, 175, 182, 89, 195, 106, 25, 97, 246, 128, 250, 48, 131, 74, 231, 81, 30, 7, 10, 241, 167, 143, 203, 207, 47, 177, 18, 148, 182, 234, 221, 2, 101, 9, 105, 103, 219, 1, 41, 197, 39, 172, 155, 202, 171, 202, 136, 229, 55, 18, 155, 74, 177, 151, 90, 44, 37, 250, 148 }, "", false, null, null, "SYSTEM", null, null, false, new byte[] { 117, 137, 16, 64, 126, 178, 70, 22, 50, 149, 179, 223, 234, 78, 170, 210, 138, 116, 148, 13, 143, 152, 10, 190, 82, 156, 7, 142, 25, 237, 165, 74, 19, 63, 115, 181, 197, 125, 170, 53, 180, 67, 111, 221, 130, 52, 148, 221, 44, 25, 110, 252, 136, 117, 224, 18, 63, 15, 182, 37, 19, 148, 237, 184, 58, 241, 136, 96, 57, 249, 50, 251, 106, 178, 103, 31, 44, 130, 4, 180, 60, 148, 106, 223, 211, 245, 44, 148, 9, 116, 247, 56, 91, 248, 171, 216, 95, 150, 182, 170, 252, 199, 177, 236, 26, 156, 75, 141, 207, 107, 52, 127, 252, 187, 166, 141, 219, 28, 164, 124, 152, 140, 180, 72, 140, 37, 205, 255 }, "e9822a72-e9b9-4b46-a9ac-d2a5dacf89bb", false, "system" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Location", "Name" },
                values: new object[,]
                {
                    { "a289d674-596c-41a8-88ba-86c9f04110ac", "Cape Town", "Main Branch" },
                    { "b0a98d11-27bd-431b-a362-8d1f551175da", "Sandton", "Business Branch" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "781f8f7f-1119-4bfe-a535-8fec3de78bf4", "38c90fde-a178-4660-b2bc-bc258a4ee4d5", "UserRole" },
                    { "45b48315-64e1-4aea-ba43-1267476e0bea", "adf4cb12-d93b-406d-baf5-45925ef35cf9", "UserRole" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "781f8f7f-1119-4bfe-a535-8fec3de78bf4", "38c90fde-a178-4660-b2bc-bc258a4ee4d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45b48315-64e1-4aea-ba43-1267476e0bea", "adf4cb12-d93b-406d-baf5-45925ef35cf9" });

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: "a289d674-596c-41a8-88ba-86c9f04110ac");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: "b0a98d11-27bd-431b-a362-8d1f551175da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b48315-64e1-4aea-ba43-1267476e0bea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781f8f7f-1119-4bfe-a535-8fec3de78bf4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38c90fde-a178-4660-b2bc-bc258a4ee4d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf4cb12-d93b-406d-baf5-45925ef35cf9");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "referenceNumber",
                table: "Transactions",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e186cf2-12e7-4d3e-b8bd-ff5d5aad9132", true, null, "Role", "admin", "ADMIN" },
                    { "7388eaf1-b867-43ab-bba4-dd7bb4bff22d", true, null, "Role", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Deactivated", "Discriminator", "Email", "EmailAddress", "EmailConfirmed", "FirstName", "HashedPassword", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaltPassword", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b2f605c6-07c7-47fe-a443-22eddf538c7d", 0, "3db249cd-f4bd-4783-a15c-9c8a81269514", false, "User", null, "", false, "", new byte[] { 232, 137, 206, 177, 135, 208, 20, 218, 89, 128, 144, 88, 196, 223, 137, 200, 5, 48, 255, 92, 253, 205, 8, 210, 41, 147, 15, 187, 112, 125, 38, 111, 71, 63, 160, 143, 50, 4, 38, 40, 254, 50, 151, 106, 227, 139, 3, 111, 90, 166, 188, 67, 20, 227, 185, 47, 235, 206, 230, 108, 221, 98, 2, 130 }, "", false, null, null, "ADMIN", null, null, false, new byte[] { 80, 32, 148, 104, 21, 238, 162, 26, 80, 72, 137, 218, 111, 25, 234, 183, 197, 42, 180, 198, 249, 65, 197, 76, 115, 192, 244, 125, 218, 203, 236, 100, 192, 249, 97, 239, 54, 238, 157, 20, 191, 253, 204, 132, 215, 222, 38, 246, 129, 202, 144, 127, 236, 175, 148, 152, 169, 244, 246, 218, 162, 140, 97, 86, 211, 108, 114, 21, 210, 241, 247, 149, 31, 64, 14, 187, 7, 8, 216, 219, 8, 89, 143, 13, 45, 181, 179, 55, 181, 230, 248, 10, 252, 97, 253, 209, 220, 16, 104, 125, 71, 103, 223, 129, 182, 19, 43, 5, 97, 162, 138, 181, 140, 151, 146, 209, 205, 81, 222, 229, 19, 0, 37, 107, 249, 47, 233, 62 }, "0fa1944a-5352-4709-b9ef-f894cfdd0140", false, "admin" },
                    { "f2f944d7-44db-4213-8395-7bed7a42db69", 0, "3d0cd895-06a8-4cb9-80cc-4960491b35ce", false, "User", null, "", false, "", new byte[] { 232, 156, 22, 24, 235, 237, 66, 246, 106, 237, 22, 31, 13, 185, 140, 202, 166, 126, 39, 21, 165, 127, 93, 214, 128, 226, 18, 90, 83, 248, 45, 21, 139, 199, 252, 251, 94, 119, 147, 213, 111, 90, 99, 100, 36, 251, 215, 113, 37, 86, 161, 11, 45, 3, 87, 221, 221, 198, 69, 101, 4, 80, 255, 179 }, "", false, null, null, "SYSTEM", null, null, false, new byte[] { 76, 20, 164, 5, 88, 177, 145, 97, 124, 163, 127, 200, 75, 157, 208, 122, 78, 154, 188, 86, 145, 100, 155, 48, 62, 140, 23, 54, 30, 92, 47, 177, 72, 114, 36, 245, 37, 218, 112, 240, 96, 128, 97, 237, 221, 255, 233, 221, 27, 221, 21, 197, 144, 166, 102, 93, 42, 239, 194, 159, 103, 44, 105, 244, 33, 170, 83, 80, 54, 76, 59, 4, 250, 134, 164, 248, 47, 205, 39, 160, 223, 91, 245, 166, 63, 77, 210, 180, 185, 210, 72, 35, 154, 255, 160, 16, 47, 194, 143, 43, 114, 98, 255, 7, 197, 221, 22, 247, 224, 126, 223, 81, 79, 62, 218, 220, 85, 130, 248, 220, 195, 234, 30, 33, 156, 150, 188, 187 }, "a4ec2c0a-f40b-4eb0-9bc5-db48fde916c4", false, "system" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Location", "Name" },
                values: new object[,]
                {
                    { "6a71b3ce-ad5b-4ff8-9e77-17b4f1202ca2", "Cape Town", "Main Branch" },
                    { "7eba0399-3a20-4e0b-b8e6-f781574c460f", "Sandton", "Business Branch" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "1e186cf2-12e7-4d3e-b8bd-ff5d5aad9132", "b2f605c6-07c7-47fe-a443-22eddf538c7d", "UserRole" },
                    { "7388eaf1-b867-43ab-bba4-dd7bb4bff22d", "f2f944d7-44db-4213-8395-7bed7a42db69", "UserRole" }
                });
        }
    }
}
