using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class userId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceNotification_Invoices_InvoiceId",
                table: "InvoiceNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDisputes_Transactions_TransactionId",
                table: "TransactionDisputes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

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
                name: "Id",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InvoiceNotification",
                newName: "InvoiceNotificationId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44130bf1-b816-4505-860a-9a62152888b4", true, null, "Role", "admin", "ADMIN" },
                    { "dee4f99e-2ead-410c-9a9a-66ba249559a7", true, null, "Role", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Deactivated", "Discriminator", "Email", "EmailAddress", "EmailConfirmed", "FirstName", "HashedPassword", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaltPassword", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1422ff21-8d29-4ed5-9ca6-6e742c780358", 0, "3c87925a-d098-4539-88e3-05de55bd3d09", false, "User", null, "", false, "", new byte[] { 98, 20, 109, 89, 227, 153, 36, 7, 234, 93, 41, 148, 223, 157, 143, 246, 30, 64, 185, 245, 170, 138, 120, 178, 23, 128, 100, 72, 190, 74, 230, 135, 250, 31, 74, 24, 40, 130, 67, 214, 19, 30, 103, 60, 59, 1, 89, 2, 54, 36, 135, 9, 64, 12, 52, 224, 121, 4, 228, 151, 206, 5, 250, 209 }, "", false, null, null, "ADMIN", null, null, false, new byte[] { 220, 27, 242, 14, 128, 20, 250, 254, 112, 138, 203, 218, 205, 109, 193, 26, 193, 144, 146, 196, 184, 185, 225, 249, 135, 89, 236, 176, 226, 162, 83, 101, 239, 150, 162, 254, 111, 123, 206, 25, 181, 44, 44, 103, 113, 199, 248, 16, 148, 68, 10, 154, 255, 216, 23, 24, 35, 22, 77, 196, 43, 29, 247, 246, 14, 187, 145, 134, 115, 172, 3, 187, 173, 178, 198, 208, 7, 118, 147, 80, 182, 158, 30, 234, 229, 13, 246, 245, 163, 133, 99, 223, 43, 66, 99, 200, 39, 224, 203, 98, 70, 13, 2, 137, 53, 178, 217, 164, 37, 134, 217, 109, 216, 200, 60, 148, 209, 224, 110, 110, 62, 210, 35, 198, 147, 117, 254, 236 }, "1be69be5-50b2-4905-b4d1-1bf59e0a12eb", false, "admin" },
                    { "62622263-14ed-4e81-b5f9-b55c44997987", 0, "cf6eb0fc-35d8-49aa-afb1-b8a01e4f1230", false, "User", null, "", false, "", new byte[] { 199, 82, 7, 14, 198, 157, 12, 5, 68, 155, 33, 84, 179, 179, 191, 132, 28, 81, 98, 160, 236, 73, 87, 79, 233, 245, 148, 252, 171, 200, 171, 211, 84, 23, 1, 149, 28, 89, 210, 149, 130, 84, 2, 189, 218, 126, 14, 125, 195, 118, 19, 51, 145, 138, 145, 24, 81, 18, 50, 31, 142, 79, 125, 74 }, "", false, null, null, "SYSTEM", null, null, false, new byte[] { 90, 38, 252, 131, 157, 212, 71, 100, 214, 136, 24, 228, 105, 194, 114, 107, 184, 25, 220, 55, 140, 209, 183, 135, 158, 115, 153, 135, 225, 81, 58, 139, 108, 61, 190, 154, 109, 137, 119, 97, 149, 136, 172, 141, 188, 145, 207, 234, 186, 38, 128, 188, 131, 204, 53, 62, 102, 165, 249, 142, 91, 114, 69, 145, 227, 135, 42, 217, 190, 250, 205, 46, 65, 166, 55, 96, 166, 123, 49, 174, 206, 117, 130, 182, 124, 146, 212, 3, 238, 145, 106, 153, 20, 206, 128, 97, 219, 162, 37, 75, 96, 213, 186, 184, 137, 127, 105, 233, 146, 40, 106, 239, 199, 111, 0, 210, 179, 140, 18, 65, 181, 195, 125, 23, 26, 13, 114, 29 }, "fd8928af-111d-43c7-82d0-493a37dd79cb", false, "system" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Location", "Name" },
                values: new object[,]
                {
                    { "19bfdcc8-d911-4382-b22b-7ecb714d7dcf", "Cape Town", "Main Branch" },
                    { "8a5165f3-dbbd-4740-b955-2143df8fac34", "Sandton", "Business Branch" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "44130bf1-b816-4505-860a-9a62152888b4", "1422ff21-8d29-4ed5-9ca6-6e742c780358", "UserRole" },
                    { "dee4f99e-2ead-410c-9a9a-66ba249559a7", "62622263-14ed-4e81-b5f9-b55c44997987", "UserRole" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceNotification_Invoices_InvoiceId",
                table: "InvoiceNotification",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDisputes_Transactions_TransactionId",
                table: "TransactionDisputes",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceNotification_Invoices_InvoiceId",
                table: "InvoiceNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDisputes_Transactions_TransactionId",
                table: "TransactionDisputes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "44130bf1-b816-4505-860a-9a62152888b4", "1422ff21-8d29-4ed5-9ca6-6e742c780358" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dee4f99e-2ead-410c-9a9a-66ba249559a7", "62622263-14ed-4e81-b5f9-b55c44997987" });

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: "19bfdcc8-d911-4382-b22b-7ecb714d7dcf");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: "8a5165f3-dbbd-4740-b955-2143df8fac34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44130bf1-b816-4505-860a-9a62152888b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee4f99e-2ead-410c-9a9a-66ba249559a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1422ff21-8d29-4ed5-9ca6-6e742c780358");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62622263-14ed-4e81-b5f9-b55c44997987");

            migrationBuilder.RenameColumn(
                name: "InvoiceNotificationId",
                table: "InvoiceNotification",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceNotification_Invoices_InvoiceId",
                table: "InvoiceNotification",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDisputes_Transactions_TransactionId",
                table: "TransactionDisputes",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
