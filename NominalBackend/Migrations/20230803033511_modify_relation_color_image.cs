using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class modify_relation_color_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Color_Colorid",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_Colorid",
                table: "Color");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134ffd06-17b1-4e9f-a985-bf215f83a887");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f536b409-4908-49a8-ad2f-c8fd299c1df3");

            migrationBuilder.DropColumn(
                name: "Colorid",
                table: "Color");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28e234d8-e57d-422c-a80f-e8415b404921", "2", "Client", "Client" },
                    { "a5580ce5-6775-4200-a609-f9659ca64ffd", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e234d8-e57d-422c-a80f-e8415b404921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5580ce5-6775-4200-a609-f9659ca64ffd");

            migrationBuilder.AddColumn<int>(
                name: "Colorid",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "134ffd06-17b1-4e9f-a985-bf215f83a887", "1", "Admin", "Admin" },
                    { "f536b409-4908-49a8-ad2f-c8fd299c1df3", "2", "Client", "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_Colorid",
                table: "Color",
                column: "Colorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Color_Colorid",
                table: "Color",
                column: "Colorid",
                principalTable: "Color",
                principalColumn: "id");
        }
    }
}
