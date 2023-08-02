using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class adding_color_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52664e1a-f3a5-4c5a-9705-64f926ff252a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88fed88c-42e7-4fe9-b971-c8acd728140d");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HexDicemal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.id);
                    table.ForeignKey(
                        name: "FK_Color_Color_Colorid",
                        column: x => x.Colorid,
                        principalTable: "Color",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d08e5442-588e-4b45-8106-ddd60437433e", "1", "Admin", "Admin" },
                    { "d429c092-35c0-40ef-91d7-24f077e71627", "2", "Client", "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ColorId",
                table: "Images",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_Colorid",
                table: "Color",
                column: "Colorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Color_ColorId",
                table: "Images",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Color_ColorId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Images_ColorId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08e5442-588e-4b45-8106-ddd60437433e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d429c092-35c0-40ef-91d7-24f077e71627");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52664e1a-f3a5-4c5a-9705-64f926ff252a", "2", "Client", "Client" },
                    { "88fed88c-42e7-4fe9-b971-c8acd728140d", "1", "Admin", "Admin" }
                });
        }
    }
}
