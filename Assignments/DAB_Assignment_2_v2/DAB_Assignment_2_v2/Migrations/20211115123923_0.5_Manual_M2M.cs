using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _05_Manual_M2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberSociety");

            migrationBuilder.CreateTable(
                name: "SocietyMemberRelations",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_SocietyMemberRelations_SocietyId",
                table: "SocietyMemberRelations",
                column: "SocietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocietyMemberRelations");

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
        }
    }
}
