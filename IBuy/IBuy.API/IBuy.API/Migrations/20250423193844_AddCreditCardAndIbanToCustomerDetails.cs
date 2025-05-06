using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBuy.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCreditCardAndIbanToCustomerDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCard",
                table: "CustomerDetails",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "CustomerDetails",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "CustomerDetails");
        }
    }
}
