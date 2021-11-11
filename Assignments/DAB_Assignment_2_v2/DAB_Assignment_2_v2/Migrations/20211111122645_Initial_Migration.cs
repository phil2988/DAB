using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcitivtyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpr = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => new { x.RoomKey, x.RoomAdress });
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
                    Whiteboard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomProperties", x => x.PropertyId);
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
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MuniciplaityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.SocietyId);
                    table.ForeignKey(
                        name: "FK_Society_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "MemberSociety",
                columns: table => new
                {
                    MembersMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietiesSocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSociety", x => new { x.MembersMemberId, x.SocietiesSocietyId });
                    table.ForeignKey(
                        name: "FK_MemberSociety_Member_MembersMemberId",
                        column: x => x.MembersMemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberSociety_Society_SocietiesSocietyId",
                        column: x => x.SocietiesSocietyId,
                        principalTable: "Society",
                        principalColumn: "SocietyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberSociety_SocietiesSocietyId",
                table: "MemberSociety",
                column: "SocietiesSocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_BookedByMemberId",
                table: "RoomBooking",
                column: "BookedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_RoomKey_RoomAdress",
                table: "RoomBooking",
                columns: new[] { "RoomKey", "RoomAdress" });

            migrationBuilder.CreateIndex(
                name: "IX_Society_ActivityId",
                table: "Society",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_MunicipalityId",
                table: "Society",
                column: "MunicipalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "MemberSociety");

            migrationBuilder.DropTable(
                name: "RoomBooking");

            migrationBuilder.DropTable(
                name: "RoomProperties");

            migrationBuilder.DropTable(
                name: "SocietyMemberRelations");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Municipality");
        }
    }
}
