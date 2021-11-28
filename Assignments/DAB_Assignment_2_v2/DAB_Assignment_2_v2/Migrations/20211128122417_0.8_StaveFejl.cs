using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _08_StaveFejl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Society_Activity_ActivityId",
                table: "Society");

            migrationBuilder.DropColumn(
                name: "AcivityId",
                table: "Society");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityId",
                table: "Society",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Society_Activity_ActivityId",
                table: "Society",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Society_Activity_ActivityId",
                table: "Society");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityId",
                table: "Society",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AcivityId",
                table: "Society",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Society_Activity_ActivityId",
                table: "Society",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
