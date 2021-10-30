using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreTest.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_people_cars_CarLicensePlate",
                table: "people");

            migrationBuilder.DropIndex(
                name: "IX_people_CarLicensePlate",
                table: "people");

            migrationBuilder.DropColumn(
                name: "CarLicensePlate",
                table: "people");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cars_PersonID",
                table: "cars",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_people_PersonID",
                table: "cars",
                column: "PersonID",
                principalTable: "people",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_people_PersonID",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_PersonID",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "cars");

            migrationBuilder.AddColumn<string>(
                name: "CarLicensePlate",
                table: "people",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_people_CarLicensePlate",
                table: "people",
                column: "CarLicensePlate");

            migrationBuilder.AddForeignKey(
                name: "FK_people_cars_CarLicensePlate",
                table: "people",
                column: "CarLicensePlate",
                principalTable: "cars",
                principalColumn: "LicensePlate",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
