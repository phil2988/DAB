using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _01_Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpr = table.Column<int>(type: "int", nullable: false),
                    IsChairman = table.Column<bool>(type: "bit", nullable: false),
                    KeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomKey = table.Column<int>(type: "int", nullable: false),
                    RoomAdress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    RoomAvailability = table.Column<TimeSpan>(type: "time", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => new { x.RoomKey, x.RoomAdress });
                });

            migrationBuilder.CreateTable(
                name: "Key",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomKey = table.Column<int>(type: "int", nullable: false),
                    RoomAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Key_Member_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cvr = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MuniciplaityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.SocietyId);
                    table.ForeignKey(
                        name: "FK_Society_Municipality_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomBooking",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingSpan = table.Column<TimeSpan>(type: "time", nullable: false),
                    BookedByMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomKey = table.Column<int>(type: "int", nullable: false),
                    RoomAdress = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBooking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Member_BookedByMemberId",
                        column: x => x.BookedByMemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Room_RoomKey_RoomAdress",
                        columns: x => new { x.RoomKey, x.RoomAdress },
                        principalTable: "Room",
                        principalColumns: new[] { "RoomKey", "RoomAdress" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomProperties",
                columns: table => new
                {
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeMachine = table.Column<bool>(type: "bit", nullable: false),
                    Water = table.Column<bool>(type: "bit", nullable: false),
                    Toilet = table.Column<bool>(type: "bit", nullable: false),
                    Chairs = table.Column<bool>(type: "bit", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false),
                    SoccerGoals = table.Column<bool>(type: "bit", nullable: false),
                    SoundSystem = table.Column<bool>(type: "bit", nullable: false),
                    Tables = table.Column<bool>(type: "bit", nullable: false),
                    Whiteboard = table.Column<bool>(type: "bit", nullable: false),
                    RoomKey = table.Column<int>(type: "int", nullable: true),
                    RoomAdress = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomProperties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_RoomProperties_Room_RoomKey_RoomAdress",
                        columns: x => new { x.RoomKey, x.RoomAdress },
                        principalTable: "Room",
                        principalColumns: new[] { "RoomKey", "RoomAdress" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcitivtyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Society",
                        principalColumn: "SocietyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocietyMemberRelations",
                columns: table => new
                {
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocietyMemberRelations", x => new { x.MemberId, x.SocietyId });
                    table.ForeignKey(
                        name: "FK_SocietyMemberRelations_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocietyMemberRelations_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Society",
                        principalColumn: "SocietyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SocietyId",
                table: "Activity",
                column: "SocietyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_BookedByMemberId",
                table: "RoomBooking",
                column: "BookedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_RoomKey_RoomAdress",
                table: "RoomBooking",
                columns: new[] { "RoomKey", "RoomAdress" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomProperties_RoomKey_RoomAdress",
                table: "RoomProperties",
                columns: new[] { "RoomKey", "RoomAdress" });

            migrationBuilder.CreateIndex(
                name: "IX_Society_MunicipalityId",
                table: "Society",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyMemberRelations_SocietyId",
                table: "SocietyMemberRelations",
                column: "SocietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "RoomBooking");

            migrationBuilder.DropTable(
                name: "RoomProperties");

            migrationBuilder.DropTable(
                name: "SocietyMemberRelations");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "Municipality");
        }
    }
}
