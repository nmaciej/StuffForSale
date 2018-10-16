using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffForSale.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Orders",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "AddressLine2");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Orders",
                nullable: false,
                defaultValue: "");
        }
    }
}
