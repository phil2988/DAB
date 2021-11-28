using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2_v2.Migrations
{
    public partial class _010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Society_Municipality_MunicipalityId",
                table: "Society");

            migrationBuilder.AlterColumn<Guid>(
                name: "MunicipalityId",
                table: "Society",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Society_Municipality_MunicipalityId",
                table: "Society",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "MunicipalityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Society_Municipality_MunicipalityId",
                table: "Society");

            migrationBuilder.AlterColumn<Guid>(
                name: "MunicipalityId",
                table: "Society",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Society_Municipality_MunicipalityId",
                table: "Society",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "MunicipalityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
