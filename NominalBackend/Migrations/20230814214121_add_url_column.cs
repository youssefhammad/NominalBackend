using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class add_url_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f354a3e-bf2d-483b-bee5-18a5bfd0076c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18b7325-dc71-4dee-aeaf-3ae2a081d7d9");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "StaticImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f1865f2-8123-4250-8310-daf0f946971e", "1", "Admin", "Admin" },
                    { "d92de3ab-ffde-4986-91f1-a89d406851ce", "2", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f1865f2-8123-4250-8310-daf0f946971e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d92de3ab-ffde-4986-91f1-a89d406851ce");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "StaticImages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f354a3e-bf2d-483b-bee5-18a5bfd0076c", "1", "Admin", "Admin" },
                    { "f18b7325-dc71-4dee-aeaf-3ae2a081d7d9", "2", "Client", "Client" }
                });
        }
    }
}
