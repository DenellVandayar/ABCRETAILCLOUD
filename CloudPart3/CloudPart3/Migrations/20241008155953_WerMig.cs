using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudPart3.Migrations
{
    /// <inheritdoc />
    public partial class WerMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CheckoutOrders",
                newName: "CheckoutOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckoutOrderId",
                table: "CheckoutOrders",
                newName: "OrderId");
        }
    }
}
