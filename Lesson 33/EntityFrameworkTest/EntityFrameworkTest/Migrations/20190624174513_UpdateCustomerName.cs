using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkTest.Migrations
{
    public partial class UpdateCustomerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Customers",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
