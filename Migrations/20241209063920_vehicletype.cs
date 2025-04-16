using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTollCollection.Migrations
{
    /// <inheritdoc />
    public partial class vehicletype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "Vehicles",
                newName: "vehicleType");

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "vehicleType",
                table: "Vehicles",
                newName: "VehicleType");
        }
    }
}
