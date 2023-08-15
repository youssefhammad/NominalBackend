using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class add_image_name_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5561855a-1afb-4d93-9184-95cf888d1833");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e4e1ed-3fa1-43e5-83ee-57b3870f9340");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "StaticImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d1cbf9b-bbeb-41d0-8a93-b4fb93ac6514", "2", "Client", "Client" },
                    { "5479bcd8-3f50-4f93-bd93-a7d5f5c8c7ea", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d1cbf9b-bbeb-41d0-8a93-b4fb93ac6514");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5479bcd8-3f50-4f93-bd93-a7d5f5c8c7ea");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "StaticImages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5561855a-1afb-4d93-9184-95cf888d1833", "1", "Admin", "Admin" },
                    { "89e4e1ed-3fa1-43e5-83ee-57b3870f9340", "2", "Client", "Client" }
                });
        }
    }
}
