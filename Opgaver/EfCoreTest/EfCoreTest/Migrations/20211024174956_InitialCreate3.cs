using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreTest.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarLicensePlate",
                table: "people",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_people_cars_CarLicensePlate",
                table: "people");

            migrationBuilder.DropIndex(
                name: "IX_people_CarLicensePlate",
                table: "people");

            migrationBuilder.AlterColumn<string>(
                name: "CarLicensePlate",
                table: "people",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
