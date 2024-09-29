using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkAreaManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editedParkSpot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PreCalculatedFee",
                table: "ParkingSpots",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ParkingSpots",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreCalculatedFee",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ParkingSpots");
        }
    }
}
