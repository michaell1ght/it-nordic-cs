using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkTest.Migrations
{
    public partial class UpdateCustomerName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Customers",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "dbo",
                newName: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }
    }
}
