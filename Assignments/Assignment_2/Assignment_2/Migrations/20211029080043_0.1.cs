using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_2.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    activityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activity__BD8CC0A8B21D014C", x => x.activityName);
                });

            migrationBuilder.CreateTable(
                name: "Chairman",
                columns: table => new
                {
                    chairmanName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    _cpr = table.Column<long>(type: "bigint", nullable: true),
                    _adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    roomKey = table.Column<int>(type: "int", nullable: true),
                    locationAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chairman__1BC12E7435675000", x => x.chairmanName);
                });

            migrationBuilder.CreateTable(
                name: "Location_Properties",
                columns: table => new
                {
                    propertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _coffeeMachine = table.Column<bool>(type: "bit", nullable: true),
                    _toilet = table.Column<bool>(type: "bit", nullable: true),
                    _water = table.Column<bool>(type: "bit", nullable: true),
                    _chairs = table.Column<bool>(type: "bit", nullable: true),
                    _wifi = table.Column<bool>(type: "bit", nullable: true),
                    _whiteboard = table.Column<bool>(type: "bit", nullable: true),
                    _soccerGoals = table.Column<bool>(type: "bit", nullable: true),
                    _tables = table.Column<bool>(type: "bit", nullable: true),
                    _soundSystem = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__9C0B8C7D6BFF421A", x => x.propertyId);
                });

            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    societyCvr = table.Column<long>(type: "bigint", nullable: false),
                    _societyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    _societyAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    activityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    chairmanName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Society__41BA8D9C58F8827D", x => x.societyCvr);
                    table.ForeignKey(
                        name: "FK_Society.activityName",
                        column: x => x.activityName,
                        principalTable: "Activity",
                        principalColumn: "activityName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Society.chairmanName",
                        column: x => x.chairmanName,
                        principalTable: "Chairman",
                        principalColumn: "chairmanName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipality_Location",
                columns: table => new
                {
                    locationAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    _maxMembers = table.Column<int>(type: "int", nullable: true),
                    _locationAvailabilityStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    _locationAvailabilityStop = table.Column<TimeSpan>(type: "time", nullable: true),
                    propertyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Municipa__4FAFE91BB12ECCA8", x => x.locationAdress);
                    table.ForeignKey(
                        name: "FK.Municipality_Location.propertyId",
                        column: x => x.propertyId,
                        principalTable: "Location_Properties",
                        principalColumn: "propertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    societyCvr = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Municipality.societyCvr",
                        column: x => x.societyCvr,
                        principalTable: "Society",
                        principalColumn: "societyCvr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _roomKey = table.Column<int>(type: "int", nullable: false),
                    _maxMembers = table.Column<int>(type: "int", nullable: true),
                    _roomAvailabilityStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    _roomAvailabilityStop = table.Column<TimeSpan>(type: "time", nullable: true),
                    _bookedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    _bookedBySociety = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    _bookedStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    _bookedStop = table.Column<TimeSpan>(type: "time", nullable: true),
                    locationAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Room.locationAdress",
                        column: x => x.locationAdress,
                        principalTable: "Municipality_Location",
                        principalColumn: "locationAdress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    memberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomId = table.Column<int>(type: "int", nullable: true),
                    _name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    _adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    _cpr = table.Column<long>(type: "bigint", nullable: true),
                    locationAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.memberId);
                    table.ForeignKey(
                        name: "FK_Member.locationAdress",
                        column: x => x.locationAdress,
                        principalTable: "Municipality_Location",
                        principalColumn: "locationAdress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member.roomId",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "roomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocietyMemberRelations",
                columns: table => new
                {
                    societyCvr = table.Column<long>(type: "bigint", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__SocietyMe__membe__37A5467C",
                        column: x => x.memberId,
                        principalTable: "Member",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__SocietyMe__socie__36B12243",
                        column: x => x.societyCvr,
                        principalTable: "Society",
                        principalColumn: "societyCvr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_locationAdress",
                table: "Member",
                column: "locationAdress");

            migrationBuilder.CreateIndex(
                name: "IX_Member_roomId",
                table: "Member",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_societyCvr",
                table: "Municipality",
                column: "societyCvr");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_Location_propertyId",
                table: "Municipality_Location",
                column: "propertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_locationAdress",
                table: "Room",
                column: "locationAdress");

            migrationBuilder.CreateIndex(
                name: "IX_Society_activityName",
                table: "Society",
                column: "activityName");

            migrationBuilder.CreateIndex(
                name: "IX_Society_chairmanName",
                table: "Society",
                column: "chairmanName");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyMemberRelations_societyCvr",
                table: "SocietyMemberRelations",
                column: "societyCvr");

            migrationBuilder.CreateIndex(
                name: "UQ__SocietyM__ABCC67CEC7F0F4D5",
                table: "SocietyMemberRelations",
                columns: new[] { "memberId", "societyCvr" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "SocietyMemberRelations");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Chairman");

            migrationBuilder.DropTable(
                name: "Municipality_Location");

            migrationBuilder.DropTable(
                name: "Location_Properties");
        }
    }
}
