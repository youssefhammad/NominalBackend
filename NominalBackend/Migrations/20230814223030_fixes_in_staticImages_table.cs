using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixes_in_staticImages_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f1865f2-8123-4250-8310-daf0f946971e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d92de3ab-ffde-4986-91f1-a89d406851ce");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StaticImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5561855a-1afb-4d93-9184-95cf888d1833", "1", "Admin", "Admin" },
                    { "89e4e1ed-3fa1-43e5-83ee-57b3870f9340", "2", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5561855a-1afb-4d93-9184-95cf888d1833");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e4e1ed-3fa1-43e5-83ee-57b3870f9340");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StaticImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f1865f2-8123-4250-8310-daf0f946971e", "1", "Admin", "Admin" },
                    { "d92de3ab-ffde-4986-91f1-a89d406851ce", "2", "Client", "Client" }
                });
        }
    }
}
