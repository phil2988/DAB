using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_2.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_bookedByName",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "_bookedBySociety",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "_bookedStart",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "_bookedStop",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "roomId",
                table: "Room",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RoomForeginKey",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomBooking",
                columns: table => new
                {
                    RoomBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedByMemberMemberId = table.Column<int>(type: "int", nullable: true),
                    BookedBySocietySocietyCvr = table.Column<long>(type: "bigint", nullable: true),
                    LocationAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBooking", x => x.RoomBookingId);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Member_BookedByMemberMemberId",
                        column: x => x.BookedByMemberMemberId,
                        principalTable: "Member",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Society_BookedBySocietySocietyCvr",
                        column: x => x.BookedBySocietySocietyCvr,
                        principalTable: "Society",
                        principalColumn: "societyCvr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_BookedByMemberMemberId",
                table: "RoomBooking",
                column: "BookedByMemberMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_BookedBySocietySocietyCvr",
                table: "RoomBooking",
                column: "BookedBySocietySocietyCvr");

            migrationBuilder.AddForeignKey(
                name: "FK_Room.RoomId",
                table: "Room",
                column: "roomId",
                principalTable: "RoomBooking",
                principalColumn: "RoomBookingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room.RoomId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "RoomBooking");

            migrationBuilder.DropColumn(
                name: "RoomForeginKey",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "roomId",
                table: "Room",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "_bookedByName",
                table: "Room",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_bookedBySociety",
                table: "Room",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "_bookedStart",
                table: "Room",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "_bookedStop",
                table: "Room",
                type: "time",
                nullable: true);
        }
    }
}
