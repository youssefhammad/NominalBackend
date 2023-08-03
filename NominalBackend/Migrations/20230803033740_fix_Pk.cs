using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class fix_Pk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e234d8-e57d-422c-a80f-e8415b404921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5580ce5-6775-4200-a609-f9659ca64ffd");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Color",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "727d3c42-77eb-4370-a706-2e11bd5dbf22", "1", "Admin", "Admin" },
                    { "97d02f91-fcfe-46d3-ad69-44ebf0033d90", "2", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "727d3c42-77eb-4370-a706-2e11bd5dbf22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97d02f91-fcfe-46d3-ad69-44ebf0033d90");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Color",
                newName: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28e234d8-e57d-422c-a80f-e8415b404921", "2", "Client", "Client" },
                    { "a5580ce5-6775-4200-a609-f9659ca64ffd", "1", "Admin", "Admin" }
                });
        }
    }
}
