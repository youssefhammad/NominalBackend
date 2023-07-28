using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class remove_fk_Dimentions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Items_ItemId",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ItemId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Dimensions");

            migrationBuilder.AddColumn<int>(
                name: "DimensionsId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_DimensionsId",
                table: "Items",
                column: "DimensionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Dimensions_DimensionsId",
                table: "Items",
                column: "DimensionsId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Dimensions_DimensionsId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_DimensionsId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DimensionsId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Dimensions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ItemId",
                table: "Dimensions",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_Items_ItemId",
                table: "Dimensions",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
