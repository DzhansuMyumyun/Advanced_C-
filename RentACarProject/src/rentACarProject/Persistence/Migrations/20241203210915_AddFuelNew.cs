using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("266432ef-e65b-4139-99b3-d62f75cb0cf4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1d5b0dc-8115-4980-8115-e293016fe308"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FuelTrues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("2a953675-a055-4b1b-be50-dc2a0dc18970"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 200, 160, 70, 169, 215, 16, 3, 154, 9, 125, 70, 93, 5, 72, 182, 242, 48, 181, 125, 228, 208, 84, 8, 209, 101, 206, 141, 12, 30, 166, 143, 131, 124, 37, 30, 199, 49, 192, 78, 7, 212, 60, 137, 160, 36, 102, 9, 149, 251, 126, 104, 149, 224, 181, 20, 92, 27, 73, 14, 230, 156, 135, 125, 252 }, new byte[] { 87, 179, 205, 219, 165, 161, 180, 144, 222, 118, 27, 75, 179, 45, 248, 88, 230, 187, 56, 219, 155, 110, 75, 171, 235, 63, 39, 193, 185, 3, 184, 35, 26, 132, 191, 61, 229, 161, 110, 124, 175, 128, 165, 211, 159, 146, 222, 99, 88, 215, 183, 70, 112, 79, 163, 65, 188, 118, 46, 229, 19, 194, 170, 49, 138, 19, 117, 13, 142, 215, 51, 206, 95, 166, 183, 195, 115, 166, 218, 139, 80, 37, 227, 162, 50, 148, 215, 10, 62, 148, 230, 185, 98, 83, 57, 157, 231, 195, 31, 39, 82, 133, 77, 181, 25, 252, 24, 132, 3, 42, 226, 78, 130, 201, 151, 109, 125, 14, 59, 246, 13, 254, 229, 159, 98, 181, 17, 52 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c521d4db-cb2f-4159-b262-74ccc1540c3e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2a953675-a055-4b1b-be50-dc2a0dc18970") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c521d4db-cb2f-4159-b262-74ccc1540c3e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a953675-a055-4b1b-be50-dc2a0dc18970"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FuelTrues");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f1d5b0dc-8115-4980-8115-e293016fe308"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 243, 188, 168, 172, 193, 28, 81, 15, 255, 137, 249, 216, 105, 30, 121, 42, 229, 85, 19, 156, 47, 134, 249, 185, 168, 5, 33, 229, 10, 50, 63, 101, 195, 251, 4, 210, 204, 186, 216, 49, 138, 183, 49, 100, 76, 197, 203, 83, 209, 219, 254, 34, 158, 64, 173, 177, 33, 247, 190, 180, 203, 193, 24, 28 }, new byte[] { 147, 26, 134, 13, 66, 176, 89, 198, 199, 213, 5, 97, 230, 249, 162, 17, 166, 250, 131, 88, 36, 75, 209, 240, 26, 227, 43, 104, 192, 147, 234, 101, 173, 248, 140, 29, 38, 36, 198, 249, 144, 251, 31, 35, 132, 241, 40, 4, 26, 171, 192, 17, 115, 222, 170, 234, 244, 98, 220, 246, 176, 36, 193, 255, 219, 107, 165, 241, 247, 142, 197, 206, 69, 177, 120, 165, 109, 201, 70, 123, 32, 162, 46, 49, 217, 191, 183, 92, 155, 46, 18, 59, 23, 43, 13, 129, 151, 94, 83, 28, 57, 153, 228, 120, 84, 169, 134, 135, 68, 8, 210, 89, 195, 255, 144, 162, 95, 216, 143, 203, 127, 223, 139, 180, 52, 176, 122, 12 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("266432ef-e65b-4139-99b3-d62f75cb0cf4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f1d5b0dc-8115-4980-8115-e293016fe308") });
        }
    }
}
