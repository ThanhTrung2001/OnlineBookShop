using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookShop.Migrations
{
    /// <inheritdoc />
    public partial class EditModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "UserAddresses");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "CitizenID");

            migrationBuilder.AddColumn<int>(
                name: "AddressDefaultID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CitizenID",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressDefaultID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "CitizenID",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "CitizenID",
                table: "Users",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
