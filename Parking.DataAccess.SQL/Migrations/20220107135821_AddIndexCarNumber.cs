using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.DataAccess.SQL.Migrations
{
    public partial class AddIndexCarNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarNumber",
                table: "Vehicles",
                column: "CarNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CarNumber",
                table: "Vehicles");
        }
    }
}
