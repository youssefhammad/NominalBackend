using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixing_relashions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Wishlists_WishlistId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_WishlistId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ItemId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Wishlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DimensionId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ItemId",
                table: "Wishlists",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ItemId",
                table: "Dimensions",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Items_ItemId",
                table: "Wishlists",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Items_ItemId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_ItemId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ItemId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "DimensionId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_WishlistId",
                table: "Items",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ItemId",
                table: "Dimensions",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Wishlists_WishlistId",
                table: "Items",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id");
        }
    }
}
