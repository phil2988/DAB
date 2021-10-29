using Microsoft.EntityFrameworkCore.Migrations;

namespace EfIntroSolution.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Maker = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "laptops",
                columns: table => new
                {
                    LaptopId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Speed = table.Column<float>(nullable: false),
                    Hd = table.Column<int>(nullable: false),
                    Screen = table.Column<float>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptops", x => x.LaptopId);
                    table.ForeignKey(
                        name: "FK_laptops_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pcs",
                columns: table => new
                {
                    PcId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Speed = table.Column<float>(nullable: false),
                    Hd = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pcs", x => x.PcId);
                    table.ForeignKey(
                        name: "FK_pcs_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "printers",
                columns: table => new
                {
                    PrinterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_printers", x => x.PrinterId);
                    table.ForeignKey(
                        name: "FK_printers_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_laptops_ProductId",
                table: "laptops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pcs_ProductId",
                table: "pcs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_printers_ProductId",
                table: "printers",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "laptops");

            migrationBuilder.DropTable(
                name: "pcs");

            migrationBuilder.DropTable(
                name: "printers");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
