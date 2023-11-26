using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hells_Tire.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HellsTireCategories",
                columns: table => new
                {
                    HellsTireCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HellsTireCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsTireCategorySlug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HellsTireCategories", x => x.HellsTireCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "HellsTireProducts",
                columns: table => new
                {
                    HellsTireProductID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HellsTireProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsTireProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsTireProductDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HellsTireProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HellsTireCategoryID = table.Column<long>(type: "bigint", nullable: false),
                    HellsTireProductImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HellsTireProducts", x => x.HellsTireProductID);
                    table.ForeignKey(
                        name: "FK_HellsTireProducts_HellsTireCategories_HellsTireCategoryID",
                        column: x => x.HellsTireCategoryID,
                        principalTable: "HellsTireCategories",
                        principalColumn: "HellsTireCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HellsTireProducts_HellsTireCategoryID",
                table: "HellsTireProducts",
                column: "HellsTireCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HellsTireProducts");

            migrationBuilder.DropTable(
                name: "HellsTireCategories");
        }
    }
}
