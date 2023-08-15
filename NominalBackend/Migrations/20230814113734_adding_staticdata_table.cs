using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class adding_staticdata_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "518d4c3e-dc52-4396-9cfc-442599c10b33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d344f7-8d10-413f-a111-333bec85c7eb");

            migrationBuilder.CreateTable(
                name: "staticData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staticData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92fcca97-ebf5-4e13-988f-369c66f2448a", "1", "Admin", "Admin" },
                    { "e9d91c2f-677f-4e8f-99f6-bc93e14d4c43", "2", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "staticData");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92fcca97-ebf5-4e13-988f-369c66f2448a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d91c2f-677f-4e8f-99f6-bc93e14d4c43");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "518d4c3e-dc52-4396-9cfc-442599c10b33", "1", "Admin", "Admin" },
                    { "c4d344f7-8d10-413f-a111-333bec85c7eb", "2", "Client", "Client" }
                });
        }
    }
}
