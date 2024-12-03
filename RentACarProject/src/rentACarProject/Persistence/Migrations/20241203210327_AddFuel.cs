using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFuel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("92ea12b9-3972-472c-992b-9e8acb5d74e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("454b5950-09bb-4217-b4ec-0b3986bcd829"));

            migrationBuilder.AddColumn<Guid>(
                name: "FuelTrueId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTrues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTrues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuels.Admin", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuels.Read", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuels.Write", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuels.Create", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuels.Update", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fuels.Delete", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTrues.Admin", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTrues.Read", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTrues.Write", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTrues.Create", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTrues.Update", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTrues.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f1d5b0dc-8115-4980-8115-e293016fe308"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 243, 188, 168, 172, 193, 28, 81, 15, 255, 137, 249, 216, 105, 30, 121, 42, 229, 85, 19, 156, 47, 134, 249, 185, 168, 5, 33, 229, 10, 50, 63, 101, 195, 251, 4, 210, 204, 186, 216, 49, 138, 183, 49, 100, 76, 197, 203, 83, 209, 219, 254, 34, 158, 64, 173, 177, 33, 247, 190, 180, 203, 193, 24, 28 }, new byte[] { 147, 26, 134, 13, 66, 176, 89, 198, 199, 213, 5, 97, 230, 249, 162, 17, 166, 250, 131, 88, 36, 75, 209, 240, 26, 227, 43, 104, 192, 147, 234, 101, 173, 248, 140, 29, 38, 36, 198, 249, 144, 251, 31, 35, 132, 241, 40, 4, 26, 171, 192, 17, 115, 222, 170, 234, 244, 98, 220, 246, 176, 36, 193, 255, 219, 107, 165, 241, 247, 142, 197, 206, 69, 177, 120, 165, 109, 201, 70, 123, 32, 162, 46, 49, 217, 191, 183, 92, 155, 46, 18, 59, 23, 43, 13, 129, 151, 94, 83, 28, 57, 153, 228, 120, 84, 169, 134, 135, 68, 8, 210, 89, 195, 255, 144, 162, 95, 216, 143, 203, 127, 223, 139, 180, 52, 176, 122, 12 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("266432ef-e65b-4139-99b3-d62f75cb0cf4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f1d5b0dc-8115-4980-8115-e293016fe308") });

            migrationBuilder.CreateIndex(
                name: "IX_Models_FuelTrueId",
                table: "Models",
                column: "FuelTrueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_FuelTrues_FuelTrueId",
                table: "Models",
                column: "FuelTrueId",
                principalTable: "FuelTrues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_FuelTrues_FuelTrueId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "FuelTrues");

            migrationBuilder.DropIndex(
                name: "IX_Models_FuelTrueId",
                table: "Models");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("266432ef-e65b-4139-99b3-d62f75cb0cf4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1d5b0dc-8115-4980-8115-e293016fe308"));

            migrationBuilder.DropColumn(
                name: "FuelTrueId",
                table: "Models");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("454b5950-09bb-4217-b4ec-0b3986bcd829"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 199, 144, 43, 129, 243, 130, 228, 184, 140, 233, 197, 122, 86, 55, 85, 159, 30, 61, 35, 104, 76, 201, 224, 163, 49, 135, 63, 138, 115, 96, 222, 3, 23, 186, 31, 211, 183, 33, 219, 221, 242, 169, 232, 75, 10, 118, 188, 47, 156, 246, 25, 110, 59, 178, 173, 59, 93, 111, 158, 68, 22, 98, 190, 76 }, new byte[] { 246, 141, 201, 154, 230, 96, 97, 192, 47, 230, 209, 87, 87, 30, 72, 182, 111, 65, 161, 114, 206, 127, 245, 249, 220, 21, 255, 157, 175, 72, 158, 237, 143, 51, 136, 204, 185, 52, 155, 195, 130, 125, 62, 53, 122, 202, 101, 178, 171, 63, 210, 238, 170, 79, 222, 59, 240, 250, 41, 65, 185, 158, 118, 200, 246, 170, 228, 154, 80, 200, 232, 197, 89, 130, 61, 129, 117, 74, 179, 31, 247, 230, 78, 114, 16, 12, 109, 15, 31, 81, 25, 241, 73, 155, 110, 255, 181, 177, 139, 148, 19, 98, 77, 213, 187, 84, 65, 152, 212, 221, 136, 41, 125, 127, 153, 153, 156, 133, 224, 82, 23, 158, 152, 135, 167, 6, 8, 192 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("92ea12b9-3972-472c-992b-9e8acb5d74e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("454b5950-09bb-4217-b4ec-0b3986bcd829") });
        }
    }
}
