using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreTest.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarLicensePlate",
                table: "people",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarLicensePlate",
                table: "people");
        }
    }
}
