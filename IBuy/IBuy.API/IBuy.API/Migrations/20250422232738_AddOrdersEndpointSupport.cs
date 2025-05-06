using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBuy.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersEndpointSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3484e37c-4fd7-42e2-938c-1d82ad7d41ef"),
                column: "Quantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87f51894-f013-4dc4-bc7c-761f74b12389"),
                column: "Quantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e8b5685-1366-4e53-b99c-016f75bfaa09"),
                column: "Quantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1c62e4d-bfe5-41ae-9050-e3c1e2f10dce"),
                column: "Quantity",
                value: 60);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3484e37c-4fd7-42e2-938c-1d82ad7d41ef"),
                column: "Quantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87f51894-f013-4dc4-bc7c-761f74b12389"),
                column: "Quantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e8b5685-1366-4e53-b99c-016f75bfaa09"),
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1c62e4d-bfe5-41ae-9050-e3c1e2f10dce"),
                column: "Quantity",
                value: 50);
        }
    }
}
