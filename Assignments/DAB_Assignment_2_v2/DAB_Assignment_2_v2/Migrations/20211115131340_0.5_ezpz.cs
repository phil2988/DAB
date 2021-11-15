using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _05_ezpz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Key_Member_KeyId",
                table: "Key");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "Key",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Key_MemberId",
                table: "Key",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Key_Member_MemberId",
                table: "Key",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Key_Member_MemberId",
                table: "Key");

            migrationBuilder.DropIndex(
                name: "IX_Key_MemberId",
                table: "Key");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "Key",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Key_Member_KeyId",
                table: "Key",
                column: "KeyId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
