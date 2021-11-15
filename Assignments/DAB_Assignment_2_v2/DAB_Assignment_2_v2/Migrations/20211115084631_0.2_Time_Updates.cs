using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _02_Time_Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocietyMemberRelations");

            migrationBuilder.DropColumn(
                name: "BookingSpan",
                table: "RoomBooking");

            migrationBuilder.RenameColumn(
                name: "RoomAvailability",
                table: "Room",
                newName: "RoomAvailabilityStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingEnd",
                table: "RoomBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingStart",
                table: "RoomBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RoomAvailabilityEnd",
                table: "Room",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "Cpr",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingEnd",
                table: "RoomBooking");

            migrationBuilder.DropColumn(
                name: "BookingStart",
                table: "RoomBooking");

            migrationBuilder.DropColumn(
                name: "RoomAvailabilityEnd",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "RoomAvailabilityStart",
                table: "Room",
                newName: "RoomAvailability");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BookingSpan",
                table: "RoomBooking",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "Cpr",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SocietyMemberRelations",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
