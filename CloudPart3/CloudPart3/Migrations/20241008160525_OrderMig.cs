using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudPart3.Migrations
{
    /// <inheritdoc />
    public partial class OrderMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckoutOrders",
                table: "CheckoutOrders");

            migrationBuilder.DropColumn(
                name: "CheckoutOrderId",
                table: "CheckoutOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CheckoutOrders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckoutOrders",
                table: "CheckoutOrders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckoutOrders",
                table: "CheckoutOrders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CheckoutOrders");

            migrationBuilder.AddColumn<string>(
                name: "CheckoutOrderId",
                table: "CheckoutOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckoutOrders",
                table: "CheckoutOrders",
                column: "CheckoutOrderId");
        }
    }
}
