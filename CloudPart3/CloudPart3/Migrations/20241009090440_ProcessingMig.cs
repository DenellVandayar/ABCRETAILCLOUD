using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudPart3.Migrations
{
    /// <inheritdoc />
    public partial class ProcessingMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "CheckoutOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "CheckoutOrders");
        }
    }
}
