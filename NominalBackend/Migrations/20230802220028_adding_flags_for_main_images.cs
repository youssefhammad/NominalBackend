using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class adding_flags_for_main_images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08e5442-588e-4b45-8106-ddd60437433e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d429c092-35c0-40ef-91d7-24f077e71627");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultItemColor",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultItemImage",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "134ffd06-17b1-4e9f-a985-bf215f83a887", "1", "Admin", "Admin" },
                    { "f536b409-4908-49a8-ad2f-c8fd299c1df3", "2", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134ffd06-17b1-4e9f-a985-bf215f83a887");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f536b409-4908-49a8-ad2f-c8fd299c1df3");

            migrationBuilder.DropColumn(
                name: "IsDefaultItemColor",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDefaultItemImage",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d08e5442-588e-4b45-8106-ddd60437433e", "1", "Admin", "Admin" },
                    { "d429c092-35c0-40ef-91d7-24f077e71627", "2", "Client", "Client" }
                });
        }
    }
}
