using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudPart3.Migrations
{
    /// <inheritdoc />
    public partial class QuantityMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Items",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Items");
        }
    }
}
