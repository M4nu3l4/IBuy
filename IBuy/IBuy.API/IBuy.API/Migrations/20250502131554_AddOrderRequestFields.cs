using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBuy.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderRequestFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNote",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPendingApproval",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequestedAction",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNote",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsPendingApproval",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RequestedAction",
                table: "Transactions");
        }
    }
}
