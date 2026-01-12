using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudPart3.Migrations
{
    /// <inheritdoc />
    public partial class trMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "CartOrders");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDateTime",
                table: "CartOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDateTime",
                table: "CartOrders");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "CartOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
