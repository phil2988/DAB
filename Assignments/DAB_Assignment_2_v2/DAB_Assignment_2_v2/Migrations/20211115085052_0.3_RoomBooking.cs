using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _03_RoomBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBooking_Room_RoomKey_RoomAdress",
                table: "RoomBooking");

            migrationBuilder.AlterColumn<int>(
                name: "RoomKey",
                table: "RoomBooking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RoomAdress",
                table: "RoomBooking",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBooking_Room_RoomKey_RoomAdress",
                table: "RoomBooking",
                columns: new[] { "RoomKey", "RoomAdress" },
                principalTable: "Room",
                principalColumns: new[] { "RoomKey", "RoomAdress" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBooking_Room_RoomKey_RoomAdress",
                table: "RoomBooking");

            migrationBuilder.AlterColumn<int>(
                name: "RoomKey",
                table: "RoomBooking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomAdress",
                table: "RoomBooking",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBooking_Room_RoomKey_RoomAdress",
                table: "RoomBooking",
                columns: new[] { "RoomKey", "RoomAdress" },
                principalTable: "Room",
                principalColumns: new[] { "RoomKey", "RoomAdress" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
