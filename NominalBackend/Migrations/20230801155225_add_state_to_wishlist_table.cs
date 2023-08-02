using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominalBackend.Migrations
{
    /// <inheritdoc />
    public partial class add_state_to_wishlist_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Wishlists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Wishlists");
        }
    }
}
