using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class create_table_static_images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92fcca97-ebf5-4e13-988f-369c66f2448a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d91c2f-677f-4e8f-99f6-bc93e14d4c43");

            migrationBuilder.CreateTable(
                name: "StaticImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticImages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f354a3e-bf2d-483b-bee5-18a5bfd0076c", "1", "Admin", "Admin" },
                    { "f18b7325-dc71-4dee-aeaf-3ae2a081d7d9", "2", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f354a3e-bf2d-483b-bee5-18a5bfd0076c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18b7325-dc71-4dee-aeaf-3ae2a081d7d9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92fcca97-ebf5-4e13-988f-369c66f2448a", "1", "Admin", "Admin" },
                    { "e9d91c2f-677f-4e8f-99f6-bc93e14d4c43", "2", "Client", "Client" }
                });
        }
    }
}
